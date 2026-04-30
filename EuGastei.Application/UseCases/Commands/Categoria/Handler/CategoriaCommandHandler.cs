using AutoMapper;
using EuGastei.Application.DTOs.Categoria;
using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using MediatR;

namespace EuGastei.Application.UseCases.Commands.Categoria.Handler;

public class CategoriaCommandHandler : IRequestHandler<CategoriaAdicionarCommand, CategoriaRespostaDTO>,
                                      IRequestHandler<CategoriaAtualizarCommand, CategoriaRespostaDTO>,
                                      IRequestHandler<CategoriaRemoverCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaCommandHandler(IMapper mapper, ICategoriaRepository categoryRepository)
    {
        _mapper = mapper;
        _categoriaRepository = categoryRepository;
    }

    public async Task<CategoriaRespostaDTO> Handle(CategoriaAdicionarCommand request, CancellationToken cancellationToken)
    {
        var categoria = EuGastei.Domain.Entities.Categoria.Criar(
            request.Dto.TenantId, 
            request.Dto.TipoDeTransacaoId, 
            request.Dto.Nome, 
            request.Dto.CategoriaPaiId);
            
        await _categoriaRepository.AdicionarAsync(categoria, cancellationToken);
        await _categoriaRepository.SaveChangesAsync();
        return _mapper.Map<CategoriaRespostaDTO>(categoria);
    }

    public async Task<CategoriaRespostaDTO> Handle(CategoriaAtualizarCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(request.Dto.Id, cancellationToken);
        if (categoria == null) throw new Exception("Categoria não encontrada");

        categoria.Atualizar(request.Dto.TipoDeTransacaoId, request.Dto.Nome, request.Dto.CategoriaPaiId);
        
        if (request.Dto.Ativo) categoria.Ativar();
        else categoria.Desativar();

        await _categoriaRepository.SaveChangesAsync();
        return _mapper.Map<CategoriaRespostaDTO>(categoria);
    }

    public async Task<bool> Handle(CategoriaRemoverCommand request, CancellationToken cancellationToken)
    {
        var categoria = await _categoriaRepository.ObterPorIdAsync(request.Id, cancellationToken);
        if (categoria == null) throw new Exception("Categoria não encontrada");

        await _categoriaRepository.RemoverAsync(categoria, cancellationToken);
        await _categoriaRepository.SaveChangesAsync();
        return true;
    }
}

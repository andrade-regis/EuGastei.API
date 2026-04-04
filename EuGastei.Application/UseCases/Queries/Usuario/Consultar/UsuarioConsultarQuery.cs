using EuGastei.Application.DTOs.Usuario;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Usuario.Consultar;

public record UsuarioConsultarQuery(Guid? Id, 
                                    Guid? PerfilId,
                                    string? Nome,
                                    string? Apelido,
                                    string? Email,
                                    bool? Ativo) : IRequest<ICollection<UsuarioRespostaDTO>>;

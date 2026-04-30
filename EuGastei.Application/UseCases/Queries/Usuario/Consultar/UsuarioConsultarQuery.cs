using EuGastei.Application.DTOs.Usuario;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Usuario.Consultar;

public record UsuarioConsultarQuery(Guid? PerfilId,
                                    string? Nome,
                                    string? Apelido,
                                    string? Email,
                                    bool? Ativo) : IRequest<IEnumerable<UsuarioRespostaResponse>>;

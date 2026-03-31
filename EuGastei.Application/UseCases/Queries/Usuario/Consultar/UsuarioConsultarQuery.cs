namespace EuGastei.Application.UseCases.Queries.Usuario.Consultar;

public record UsuarioConsultarQuery(Guid? Id, 
                                    string? Perfil,
                                    string? Nome,
                                    string? Apelido,
                                    string? Email,
                                    bool? Ativo);

using EuGastei.Application.DTOs.Conta;
using MediatR;

namespace EuGastei.Application.UseCases.Queries.Conta.Consultar;

public record ContaConsultarQuery(ContaConsultarDTO Filtro) : IRequest<IEnumerable<ContaRespostaDTO>>;

using EuGastei.Domain.Enums;

namespace EuGastei.Application.Extensions
{
    public static class TiposDeErroExtensions
    {
        public static string ToString(ETiposErro erro)
        {
            return erro switch
            {
                ETiposErro.TENANT_NOME_É_OBRIGATORIO => "Obrigatório informar nome do Tenant",
                ETiposErro.TENANT_NÃO_ENCONTRADO => "Tenant não encontrado",
                _ => erro.ToString()
            };
        }
    }
}

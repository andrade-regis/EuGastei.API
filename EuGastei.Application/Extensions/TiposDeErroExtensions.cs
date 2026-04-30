using EuGastei.Domain.Enums;

namespace EuGastei.Application.Extensions
{
    public static class TiposDeErroExtensions
    {
        public static string ToString(ETiposErro erro)
        {
            return erro switch
            {
                _ => erro.ToString()
            };
        }
    }
}

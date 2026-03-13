using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public static class EntityValidator
    {
        public static void ValidarId(Guid id, ETiposErro erro)
        {
            if (id == Guid.Empty)
                throw new ArgumentException(ETiposErroExtensions.ToString(erro));
        }
    }
}

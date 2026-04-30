using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Ano
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public int Numero { get; private set; }

        private Ano() { }

        public static Ano Criar(Guid tenantId, int numero)
        {
            ValidarTenantId(tenantId);
            ValidarNumero(numero);

            return new Ano
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Numero = numero
            };
        }

        public void AtualizarNumero(int numero)
        {
            ValidarNumero(numero);
            Numero = numero;
        }

        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }

        private static void ValidarNumero(int numero)
        {
            if (numero < 2000 || numero > 2100)
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.ANO_NUMERO_INVALIDO));
        }
    }
}

using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class FormaDePagamento
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }

        private FormaDePagamento() { }

        public static FormaDePagamento Criar(Guid tenantId, string nome)
        {
            ValidarTenantId(tenantId);
            ValidarNome(nome);

            return new FormaDePagamento
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Nome = nome
            };
        }

        public void AtualizarNome(string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.FORMA_PAGAMENTO_NOME_É_OBRIGATORIO));
        }
    }
}

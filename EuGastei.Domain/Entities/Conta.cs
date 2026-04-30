using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Conta
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        private Conta() { }

        public static Conta Criar(Guid tenantId, string nome)
        {
            ValidarTenantId(tenantId);
            ValidarNome(nome);

            return new Conta
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Nome = nome,
                Ativo = true
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
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.CONTA_NOME_É_OBRIGATORIO));
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}

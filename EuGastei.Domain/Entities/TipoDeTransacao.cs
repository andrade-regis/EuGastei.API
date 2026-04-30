using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class TipoDeTransacao
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        private TipoDeTransacao() { }

        public static TipoDeTransacao Criar(Guid tenantId, string nome)
        {
            ValidarTenantId(tenantId);
            ValidarNome(nome);

            return new TipoDeTransacao
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
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TIPO_TRANSACAO_NOME_É_OBRIGATORIO));
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}

using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Perfil
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }


        private Perfil() { }
        public static Perfil Criar(Guid tenantId, string nome, string descricao)
        {
            ValidarTenantId(tenantId);
            ValidarNome(nome);
            ValidarDescricao(descricao);

            return new Perfil()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Nome = nome,
                Descricao = descricao,
                Ativo = true
            };
        }
        public static Perfil Criar(Guid id, Guid tenantId, string nome, string descricao)
        {
            ValidarId(id);
            ValidarTenantId(tenantId);
            ValidarNome(nome);
            ValidarDescricao(descricao);

            return new Perfil()
            {
                Id = id,
                TenantId = tenantId,
                Nome = nome,
                Descricao = descricao,
                Ativo = true
            };
        }


        public void AtualizarTenantId(Guid tenantId)
        {
            ValidarTenantId(tenantId);
            this.TenantId = tenantId;
        }

        public void AtualizarNome(string nome)
        {
            ValidarNome(nome);

            this.Nome = nome;
        }
        public void AtualizarDescricao(string descricao)
        {
            ValidarDescricao(descricao);

            this.Descricao = descricao;
        }
        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;


        private static void ValidarId(Guid id)
        {
            EntityValidator.ValidarId(id, ETiposErro.PERFIL_ID_INVALIDO);
        }
        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }
        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.PERFIL_NOME_É_OBRIGATORIO));
        }
        private static void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.PERFIL_DESCRICAO_É_OBRIGATORIO));
        }
    }
}

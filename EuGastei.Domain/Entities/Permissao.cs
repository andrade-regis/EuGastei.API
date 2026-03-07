namespace EuGastei.Domain.Entities
{
    public class Permissao
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public string Sigla { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        //EF CORE
        public Tenant Tenant { get; private set; }

        private Permissao() { }

        public static Permissao Criar(Guid tenantId, string sigla, string descricao)
        {
            return new Permissao()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Sigla = sigla,
                Descricao = descricao,
                Ativo = true
            };            
        }

        public void AtualizarTenantId(Guid tenantId)
            => this.TenantId = tenantId;

        public void AtualizarSigla(string sigla)
            => this.Sigla = sigla;

        public void AtualizarDescricao(string descricao)
            => this.Descricao = descricao;

        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;
    }
}

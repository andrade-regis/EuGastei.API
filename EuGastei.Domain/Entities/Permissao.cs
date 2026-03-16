using EuGastei.Domain.Enums;
using System.Runtime.CompilerServices;

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
            ValidarTenantId(tenantId);

            ValidarSigla(sigla);
            ValidarDescricao(sigla);

            return new Permissao()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Sigla = sigla,
                Descricao = descricao,
                Ativo = true
            };            
        }
        public static Permissao Criar(Guid id, Guid tenantId, string sigla, string descricao)
        {
            ValidarId(id);
            ValidarTenantId(tenantId);

            ValidarSigla(sigla);
            ValidarDescricao(sigla);

            return new Permissao()
            {
                Id = id,
                TenantId = tenantId,
                Sigla = sigla,
                Descricao = descricao,
                Ativo = true
            };
        }

        public void AtualizarTenantId(Guid tenantId)
        {
            ValidarTenantId(tenantId);

            this.TenantId = tenantId;
        }
        public void AtualizarSigla(string sigla)
        {
            ValidarSigla(sigla);

            this.Sigla = sigla;
        }
        public void AtualizarDescricao(string descricao)
        {
            ValidarDescricao(Descricao);

            this.Descricao = descricao;
        }
        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;


        private static void ValidarId(Guid id)
        {
            EntityValidator.ValidarId(id, ETiposErro.PERMISSAO_ID_INVALIDO);
        }
        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }
        private static void ValidarSigla(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.PERMISSAO_SIGLA_É_OBRIGATORIO));
        }
        private static void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.PERMISSAO_DESCRICAO_É_OBRIGATORIO));
        }
    }
}

using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class PerfilPermissao
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid PerfilId { get; private set; }
        public Guid PermissaoId { get; private set; }

        // EF Core
        public virtual Tenant Tenant { get; private set; }
        public virtual Perfil Perfil { get; private set; }
        public virtual Permissao Permissao { get; private set; }


        private PerfilPermissao() { }
        public static PerfilPermissao Criar(Guid tenantId, Guid perfilId, Guid permissaoId)
        {
            ValidarTenantId(tenantId);
            ValidarPerfilId(perfilId);
            ValidarPermissaoId(permissaoId);

            return new PerfilPermissao
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                PerfilId = perfilId,
                PermissaoId = permissaoId
            };
        }


        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }
        private static void ValidarPerfilId(Guid perfilId)
        {
            EntityValidator.ValidarId(perfilId, ETiposErro.PERFIL_ID_INVALIDO);
        }
        private static void ValidarPermissaoId(Guid permissaoId)
        {
            EntityValidator.ValidarId(permissaoId, ETiposErro.PERMISSAO_ID_INVALIDO);
        }
    }
}

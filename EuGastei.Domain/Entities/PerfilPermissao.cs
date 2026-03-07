using System;
using System.Collections.Generic;
using System.Text;

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

        public static PerfilPermissao Criar(Guid tenantId, Guid perfilId, Guid PermissaoId)
        {
            return new PerfilPermissao
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                PerfilId = perfilId,
                PermissaoId = PermissaoId
            };
        }
    }
}

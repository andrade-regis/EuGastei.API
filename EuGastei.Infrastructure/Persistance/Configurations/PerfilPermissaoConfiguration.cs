using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuGastei.Infrastructure.Persistance.Configurations
{
    public class PerfilPermissaoConfiguration : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("PerfisPermissoes");

            builder.HasKey(pp => pp.Id);
            builder.Property(pp => pp.Id).ValueGeneratedNever();

            builder.Property(pp => pp.TenantId).IsRequired();
            builder.Property(pp => pp.PerfilId).IsRequired();
            builder.Property(pp => pp.PermissaoId).IsRequired();

            builder.HasOne(pp => pp.Tenant)
                .WithMany()
                .HasForeignKey(pp => pp.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pp => pp.Perfil)
                .WithMany()
                .HasForeignKey(pp => pp.PerfilId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Permissao)
                .WithMany()
                .HasForeignKey(pp => pp.PermissaoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

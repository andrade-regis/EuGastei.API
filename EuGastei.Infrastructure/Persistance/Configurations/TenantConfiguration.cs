using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EuGastei.Infrastructure.Persistance.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenants");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedNever();

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Ativo)
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .IsRequired();
        }
    }
}

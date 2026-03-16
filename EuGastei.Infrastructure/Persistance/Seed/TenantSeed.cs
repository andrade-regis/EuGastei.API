using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed
{
    public static class TenantSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(

                Tenant.Criar(
                       new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), 
                       "Tenant-Base")                
            );
        }
    }
}

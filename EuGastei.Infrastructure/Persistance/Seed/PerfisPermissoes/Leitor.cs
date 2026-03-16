using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed.PerfisPermissoes
{
    public static class Leitor
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilPermissao>().HasData(

                //LER
                PerfilPermissao.Criar(
                    new Guid("34AF1759-A573-4240-B70C-4C7F79AE8D91"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                    new Guid("ECD85158-C4AD-4E09-868E-0B27AA5A66F7"), //PERFILID
                    new Guid("43903B1C-BDBB-4273-9FAB-654FA5C58133")  //PERMISSAOID
                )
            );
        }
    }
}


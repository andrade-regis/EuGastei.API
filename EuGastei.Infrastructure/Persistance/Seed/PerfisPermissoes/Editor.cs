using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed.PerfisPermissoes
{
    public static class Editor
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilPermissao>().HasData(

                //LER
                PerfilPermissao.Criar(
                    new Guid("D4E65550-5658-433B-8988-6E7CD7165DFA"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                    new Guid("0493C9AF-3C20-4716-BF8F-7F5A26768C21"), //PERFILID
                    new Guid("43903B1C-BDBB-4273-9FAB-654FA5C58133")  //PERMISSAOID
                ),

                //ATUALIZAR
                PerfilPermissao.Criar(
                    new Guid("222C9CCE-B783-4AB4-9F1B-4C0EE176A2FB"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("0493C9AF-3C20-4716-BF8F-7F5A26768C21"),
                    new Guid("17000CDA-E955-41AF-A633-3BD1B6359F8E")
                )
            );
        }
    }
}


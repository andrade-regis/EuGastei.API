using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed.PerfisPermissoes
{
    public static class Administrador
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilPermissao>().HasData(

                //CRIAR
                PerfilPermissao.Criar(
                    new Guid("3F172ED3-B667-4887-89B5-EE9F50858BB3"), //ID
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                    new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"), //PERFILID
                    new Guid("44A13FBF-7084-42E5-AC98-10F92DA31709")  //PERMISSAOID
                ),

                //LER
                PerfilPermissao.Criar(
                    new Guid("F96646C1-B7EF-416A-A01A-CF287E1878B6"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"),
                    new Guid("43903B1C-BDBB-4273-9FAB-654FA5C58133")
                ),

                //ATUALIZAR
                PerfilPermissao.Criar(
                    new Guid("446FEA73-A329-4489-9FCF-E5D74AE123D1"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"),
                    new Guid("17000CDA-E955-41AF-A633-3BD1B6359F8E")
                ),

                //DELETAR
                PerfilPermissao.Criar(
                    new Guid("F3A0C882-D99C-4399-9952-17A26EB329D8"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"),
                    new Guid("1871D6C3-4845-4EE2-B6AE-AC4B9EC0752D")
                )
            );
        }
    }
}



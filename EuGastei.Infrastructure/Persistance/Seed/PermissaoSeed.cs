using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed
{
    public static class PermissaoSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissao>().HasData(

                Permissao.Criar(
                         new Guid("44A13FBF-7084-42E5-AC98-10F92DA31709"), //ID
                         new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANT ID
                         "C_App", //SIGLA
                         "Permissão de Criar"), //DESCRIÇÃO

                Permissao.Criar(
                         new Guid("43903B1C-BDBB-4273-9FAB-654FA5C58133"),
                         new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                         "R_App",
                         "Permissão de Ler"),

                Permissao.Criar(
                         new Guid("17000CDA-E955-41AF-A633-3BD1B6359F8E"),
                         new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                         "U_App",
                         "Permissão de Atualizar"),

                Permissao.Criar(
                         new Guid("1871D6C3-4845-4EE2-B6AE-AC4B9EC0752D"),
                         new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                         "D_App",
                         "Permissão de Deletar")
            );
        }
    }
}

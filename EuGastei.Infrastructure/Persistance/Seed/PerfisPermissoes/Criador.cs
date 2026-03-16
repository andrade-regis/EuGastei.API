using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed.PerfisPermissoes
{
    public static class Criador
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerfilPermissao>().HasData(

                //CRIAR
                PerfilPermissao.Criar(
                    new Guid("860A03C8-0E2A-4171-B12A-CDE8E517175F"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                    new Guid("31ACD17C-7D3E-4EE7-B234-18E8C58E9888"), //PERFILID
                    new Guid("44A13FBF-7084-42E5-AC98-10F92DA31709")  //PERMISSAOID
                ),

                //LER
                PerfilPermissao.Criar(
                    new Guid("16C49466-6539-47A8-8AAF-21B5145D8FF0"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("31ACD17C-7D3E-4EE7-B234-18E8C58E9888"),
                    new Guid("43903B1C-BDBB-4273-9FAB-654FA5C58133")
                ),

                //ATUALIZAR
                PerfilPermissao.Criar(
                    new Guid("4C0B897D-5C03-4CBA-BFB4-9F1AF0CAB9BC"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("31ACD17C-7D3E-4EE7-B234-18E8C58E9888"),
                    new Guid("17000CDA-E955-41AF-A633-3BD1B6359F8E")
                ),

                //DELETAR
                PerfilPermissao.Criar(
                    new Guid("C6C54683-2A75-4E56-A0C0-F2E54F2D9C49"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    new Guid("31ACD17C-7D3E-4EE7-B234-18E8C58E9888"),
                    new Guid("1871D6C3-4845-4EE2-B6AE-AC4B9EC0752D")
                )
            );
        }
    }
}


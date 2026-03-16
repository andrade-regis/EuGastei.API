using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed
{
    public static class PerfilSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().HasData(
                Perfil.Criar(
                    new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"), //ID
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                    "Administrador", //NOME
                    "Perfil com todas as permissões e sem filtro de tenantId" //DESCRIÇÃO
                    ),

                Perfil.Criar(
                    new Guid("31ACD17C-7D3E-4EE7-B234-18E8C58E9888"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    "Criador",
                    "Perfil com todas as permissões"
                    ),

                Perfil.Criar(
                    new Guid("0493C9AF-3C20-4716-BF8F-7F5A26768C21"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    "Editor",
                    "Perfil com permissão de leitura e atualização"
                    ),

                Perfil.Criar(
                    new Guid("ECD85158-C4AD-4E09-868E-0B27AA5A66F7"),
                    new Guid("585F17FE-39A2-4698-A224-74E460CEF656"),
                    "Leitor",
                    "Perfil com permissão apenas de leitura"
                    )
            );
        }
    }
}

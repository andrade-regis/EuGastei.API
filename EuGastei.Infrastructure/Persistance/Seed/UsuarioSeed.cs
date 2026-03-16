using EuGastei.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EuGastei.Infrastructure.Persistance.Seed
{
    public static class UsuarioSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(

                Usuario.Criar(
                        new Guid("75377918-DE1C-4CC9-8332-AE5BAC97FA96"), //ID
                        new Guid("585F17FE-39A2-4698-A224-74E460CEF656"), //TENANTID
                        new Guid("0DF8E03A-44A9-43D7-8A0A-F8766507C8F4"), //PERFILID
                        "Administrador Global", //NOME
                        "Admin", //APELIDO
                        "regis.batista.andrade@outlook.com", //EMAIL
                        "") //SENHA
                
            );
        }
    }
}

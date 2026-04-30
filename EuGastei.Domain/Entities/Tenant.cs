using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DateCreated { get; private set; }

        private Tenant() { }

        public static Tenant Criar(string nome)
        {
            ValidarNome(nome);

            return new Tenant
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Ativo = true,
                DateCreated = DateTime.UtcNow
            };
        }

        public static Tenant Criar(Guid id, string nome, bool ativo, DateTime dateCreated)
        {
            ValidarId(id);
            ValidarNome(nome);

            return new Tenant
            {
                Id = id,
                Nome = nome,
                Ativo = ativo,
                DateCreated = dateCreated
            };
        }

        public void AtualizarNome(string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        private static void ValidarId(Guid id)
        {
            EntityValidator.ValidarId(id, ETiposErro.TENANT_ID_INVALIDO);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TENANT_NOME_É_OBRIGATORIO));
        }
    }
}

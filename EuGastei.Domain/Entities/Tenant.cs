using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;


        private Tenant() { }
        public static Tenant Criar(string nome)
        {
            ValidarNome(nome);

            return new Tenant
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Ativo = true
            };            
        }


        public void AtualizarNome(string nome)
        {
            ValidarNome(nome);

            this.Nome = nome;
        }
        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;
        

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TENANT_NOME_É_OBRIGATORIO));
        }        
    }
}

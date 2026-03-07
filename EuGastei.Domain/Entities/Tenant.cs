using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private Tenant() { }

        public static Tenant Criar(string nome)
        {
            if (string.IsNullOrEmpty(nome)) 
                throw new ArgumentException(ErrorTypesExtensions.ToString(TiposErro.TENANT_NOME_NÃO_ENCONTRADO));

            return new Tenant
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Ativo = true,
                DataCriacao = DateTime.UtcNow
            };            
        }

        public void AtualizarNome(string nome)
            => this.Nome = nome;           

        public void AtualizarAtivo(bool ativo)
            => this.Ativo = ativo;
    }
}

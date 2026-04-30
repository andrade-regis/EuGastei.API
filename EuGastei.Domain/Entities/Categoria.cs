using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid TipoDeTransacaoId { get; private set; }
        public Guid? CategoriaPaiId { get; private set; } // Mapping to OrigemId from diagram
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        // EF Core
        public virtual TipoDeTransacao TipoDeTransacao { get; private set; }
        public virtual Categoria? CategoriaPai { get; private set; }

        private Categoria() { }

        public static Categoria Criar(Guid tenantId, Guid tipoDeTransacaoId, string nome, Guid? categoriaPaiId = null)
        {
            ValidarTenantId(tenantId);
            ValidarTipoDeTransacaoId(tipoDeTransacaoId);
            ValidarNome(nome);

            return new Categoria
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                TipoDeTransacaoId = tipoDeTransacaoId,
                CategoriaPaiId = categoriaPaiId,
                Nome = nome,
                Ativo = true
            };
        }

        public void Atualizar(Guid tipoDeTransacaoId, string nome, Guid? categoriaPaiId)
        {
            ValidarTipoDeTransacaoId(tipoDeTransacaoId);
            ValidarNome(nome);
            TipoDeTransacaoId = tipoDeTransacaoId;
            Nome = nome;
            CategoriaPaiId = categoriaPaiId;
        }

        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }

        private static void ValidarTipoDeTransacaoId(Guid tipoDeTransacaoId)
        {
            EntityValidator.ValidarId(tipoDeTransacaoId, ETiposErro.TIPO_TRANSACAO_ID_INVALIDO);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.CATEGORIA_NOME_É_OBRIGATORIO));
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}

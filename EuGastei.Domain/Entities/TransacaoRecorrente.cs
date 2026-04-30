using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class TransacaoRecorrente
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Guid FormaDePagamentoId { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid MesInicioId { get; private set; }
        public Guid AnoInicioId { get; private set; }
        public Guid? MesFimId { get; private set; }
        public Guid? AnoFimId { get; private set; }
        public int Dia { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public EFrequenciaTransacao Frequencia { get; private set; }
        public bool Ativo { get; private set; }

        // EF Core
        public virtual Categoria Categoria { get; private set; }
        public virtual FormaDePagamento FormaDePagamento { get; private set; }
        public virtual Conta Conta { get; private set; }
        public virtual Mes MesInicio { get; private set; }
        public virtual Ano AnoInicio { get; private set; }
        public virtual Mes? MesFim { get; private set; }
        public virtual Ano? AnoFim { get; private set; }

        private TransacaoRecorrente() { }

        public static TransacaoRecorrente Criar(
            Guid tenantId,
            Guid categoriaId,
            Guid formaDePagamentoId,
            Guid contaId,
            Guid mesInicioId,
            Guid anoInicioId,
            int dia,
            decimal valor,
            string descricao,
            EFrequenciaTransacao frequencia)
        {
            ValidarTenantId(tenantId);
            ValidarCategoriaId(categoriaId);
            ValidarFormaDePagamentoId(formaDePagamentoId);
            ValidarContaId(contaId);
            ValidarMesId(mesInicioId);
            ValidarAnoId(anoInicioId);
            ValidarValor(valor);
            ValidarDescricao(descricao);

            return new TransacaoRecorrente
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                CategoriaId = categoriaId,
                FormaDePagamentoId = formaDePagamentoId,
                ContaId = contaId,
                MesInicioId = mesInicioId,
                AnoInicioId = anoInicioId,
                Dia = dia,
                Valor = valor,
                Descricao = descricao,
                Frequencia = frequencia,
                Ativo = true
            };
        }

        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
        }

        private static void ValidarCategoriaId(Guid categoriaId)
        {
            EntityValidator.ValidarId(categoriaId, ETiposErro.CATEGORIA_ID_INVALIDO);
        }

        private static void ValidarFormaDePagamentoId(Guid formaDePagamentoId)
        {
            EntityValidator.ValidarId(formaDePagamentoId, ETiposErro.FORMA_PAGAMENTO_ID_INVALIDO);
        }

        private static void ValidarContaId(Guid contaId)
        {
            EntityValidator.ValidarId(contaId, ETiposErro.CONTA_ID_INVALIDO);
        }

        private static void ValidarMesId(Guid mesId)
        {
            EntityValidator.ValidarId(mesId, ETiposErro.MES_ID_INVALIDO);
        }

        private static void ValidarAnoId(Guid anoId)
        {
            EntityValidator.ValidarId(anoId, ETiposErro.ANO_ID_INVALIDO);
        }

        private static void ValidarValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TRANSACAO_VALOR_INVALIDO));
        }

        private static void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TRANSACAO_DESCRICAO_É_OBRIGATORIA));
        }

        public void DefinirFim(Guid mesFimId, Guid anoFimId)
        {
            ValidarMesId(mesFimId);
            ValidarAnoId(anoFimId);
            MesFimId = mesFimId;
            AnoFimId = anoFimId;
        }

        public void Desativar() => Ativo = false;
        public void Reativar() => Ativo = true;
    }
}

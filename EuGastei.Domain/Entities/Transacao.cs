using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class Transacao
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Guid FormaDePagamentoId { get; private set; }
        public Guid? OrigemRecorrenciaId { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid AnoId { get; private set; }
        public Guid MesId { get; private set; }
        public int Dia { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public EStatusTransacao Status { get; private set; }

        // EF Core
        public virtual Categoria Categoria { get; private set; }
        public virtual FormaDePagamento FormaDePagamento { get; private set; }
        public virtual TransacaoRecorrente? OrigemRecorrencia { get; private set; }
        public virtual Conta Conta { get; private set; }
        public virtual Ano Ano { get; private set; }
        public virtual Mes Mes { get; private set; }

        private Transacao() { }

        public static Transacao Criar(
            Guid tenantId,
            Guid categoriaId,
            Guid formaDePagamentoId,
            Guid contaId,
            Guid anoId,
            Guid mesId,
            int dia,
            string descricao,
            decimal valor,
            EStatusTransacao status,
            Guid? origemRecorrenciaId = null)
        {
            ValidarTenantId(tenantId);
            ValidarCategoriaId(categoriaId);
            ValidarFormaDePagamentoId(formaDePagamentoId);
            ValidarContaId(contaId);
            ValidarAnoId(anoId);
            ValidarMesId(mesId);
            ValidarDescricao(descricao);
            ValidarValor(valor);

            return new Transacao
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                CategoriaId = categoriaId,
                FormaDePagamentoId = formaDePagamentoId,
                ContaId = contaId,
                AnoId = anoId,
                MesId = mesId,
                Dia = dia,
                Descricao = descricao,
                Valor = valor,
                Status = status,
                OrigemRecorrenciaId = origemRecorrenciaId
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

        private static void ValidarAnoId(Guid anoId)
        {
            EntityValidator.ValidarId(anoId, ETiposErro.ANO_ID_INVALIDO);
        }

        private static void ValidarMesId(Guid mesId)
        {
            EntityValidator.ValidarId(mesId, ETiposErro.MES_ID_INVALIDO);
        }

        private static void ValidarDescricao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TRANSACAO_DESCRICAO_É_OBRIGATORIA));
        }

        private static void ValidarValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException(ETiposErroExtensions.ToString(ETiposErro.TRANSACAO_VALOR_INVALIDO));
        }

        public void AlterarStatus(EStatusTransacao novoStatus)
        {
            Status = novoStatus;
        }

        public void AtualizarCategoriaId(Guid categoriaId)
        {
            ValidarCategoriaId(categoriaId);
            CategoriaId = categoriaId;
        }

        public void AtualizarFormaDePagamentoId(Guid formaDePagamentoId)
        {
            ValidarFormaDePagamentoId(formaDePagamentoId);
            FormaDePagamentoId = formaDePagamentoId;
        }

        public void AtualizarContaId(Guid contaId)
        {
            ValidarContaId(contaId);
            ContaId = contaId;
        }

        public void AtualizarAnoId(Guid anoId)
        {
            ValidarAnoId(anoId);
            AnoId = anoId;
        }

        public void AtualizarMesId(Guid mesId)
        {
            ValidarMesId(mesId);
            MesId = mesId;
        }

        public void AtualizarDia(int dia)
        {
            Dia = dia;
        }

        public void AtualizarDescricao(string descricao)
        {
            ValidarDescricao(descricao);
            Descricao = descricao;
        }

        public void AtualizarValor(decimal valor)
        {
            ValidarValor(valor);
            Valor = valor;
        }

        public void AtualizarOrigemRecorrenciaId(Guid? origemRecorrenciaId)
        {
            OrigemRecorrenciaId = origemRecorrenciaId;
        }
    }
}

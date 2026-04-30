using EuGastei.Domain.Enums;

namespace EuGastei.Domain.Entities
{
    public class ContaAnoMesSaldo
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid ContaId { get; private set; }
        public Guid AnoId { get; private set; }
        public Guid MesId { get; private set; }
        public decimal Receitas { get; private set; }
        public decimal Despesas { get; private set; }
        public decimal Saldo { get; private set; }

        // EF Core
        public virtual Conta Conta { get; private set; }
        public virtual Ano Ano { get; private set; }
        public virtual Mes Mes { get; private set; }

        private ContaAnoMesSaldo() { }

        public static ContaAnoMesSaldo Criar(Guid tenantId, Guid contaId, Guid anoId, Guid mesId)
        {
            ValidarTenantId(tenantId);
            ValidarContaId(contaId);
            ValidarAnoId(anoId);
            ValidarMesId(mesId);

            return new ContaAnoMesSaldo
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                ContaId = contaId,
                AnoId = anoId,
                MesId = mesId,
                Receitas = 0,
                Despesas = 0,
                Saldo = 0
            };
        }

        private static void ValidarTenantId(Guid tenantId)
        {
            EntityValidator.ValidarId(tenantId, ETiposErro.TENANT_ID_INVALIDO);
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

        public void AtualizarValores(decimal receitas, decimal despesas)
        {
            Receitas = receitas;
            Despesas = despesas;
            Saldo = receitas - despesas;
        }
    }
}

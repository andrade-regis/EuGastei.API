using System.ComponentModel.DataAnnotations;
using EuGastei.Domain.Enums;

namespace EuGastei.Application.DTOs.Transacao
{
    public class TransacaoAdicionarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar TenantId!")]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar CategoriaId!")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar FormaDePagamentoId!")]
        public Guid FormaDePagamentoId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar ContaId!")]
        public Guid ContaId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar AnoId!")]
        public Guid AnoId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar MesId!")]
        public Guid MesId { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Dia!")]
        public int Dia { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Descrição!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Valor!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar Status!")]
        public EStatusTransacao Status { get; set; }

        public Guid? OrigemRecorrenciaId { get; set; }
    }

    public class TransacaoAtualizarDTO
    {
        [Required(ErrorMessage = "Obrigatório informar ID!")]
        public Guid Id { get; set; }

        public Guid? CategoriaId { get; set; }
        public Guid? FormaDePagamentoId { get; set; }
        public Guid? ContaId { get; set; }
        public Guid? AnoId { get; set; }
        public Guid? MesId { get; set; }
        public int? Dia { get; set; }
        public string? Descricao { get; set; }
        public decimal? Valor { get; set; }
        public EStatusTransacao? Status { get; set; }
        public Guid? OrigemRecorrenciaId { get; set; }
    }

    public class TransacaoConsultarDTO
    {
        public Guid? TenantId { get; set; }
        public Guid? CategoriaId { get; set; }
        public Guid? FormaDePagamentoId { get; set; }
        public Guid? ContaId { get; set; }
        public Guid? AnoId { get; set; }
        public Guid? MesId { get; set; }
        public EStatusTransacao? Status { get; set; }
    }

    public class TransacaoRemoverDTO
    {
        public Guid Id { get; set; }
    }

    public class TransacaoRespostaDTO
    {
        public Guid Id { get; set; }
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
    }
}

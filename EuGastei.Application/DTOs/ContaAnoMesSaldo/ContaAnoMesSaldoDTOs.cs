using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.ContaAnoMesSaldo;

public class ContaAnoMesSaldoAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar ContaId!")]
    public Guid ContaId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar AnoId!")]
    public Guid AnoId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar MesId!")]
    public Guid MesId { get; set; }
}

public class ContaAnoMesSaldoAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Receitas!")]
    public decimal Receitas { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Despesas!")]
    public decimal Despesas { get; set; }
}

public class ContaAnoMesSaldoConsultarDTO
{
    public Guid? TenantId { get; set; }
    public Guid? ContaId { get; set; }
    public Guid? AnoId { get; set; }
    public Guid? MesId { get; set; }
}

public class ContaAnoMesSaldoRemoverDTO
{
    public Guid Id { get; set; }
}

public class ContaAnoMesSaldoRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid ContaId { get; set; }
    public Guid AnoId { get; set; }
    public Guid MesId { get; set; }
    public decimal Receitas { get; set; }
    public decimal Despesas { get; set; }
    public decimal Saldo { get; set; }
}

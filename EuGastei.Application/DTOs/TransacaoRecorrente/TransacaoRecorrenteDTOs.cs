using System.ComponentModel.DataAnnotations;
using EuGastei.Domain.Enums;

namespace EuGastei.Application.DTOs.TransacaoRecorrente;

public class TransacaoRecorrenteAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar CategoriaId!")]
    public Guid CategoriaId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar FormaDePagamentoId!")]
    public Guid FormaDePagamentoId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar ContaId!")]
    public Guid ContaId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar MesInicioId!")]
    public Guid MesInicioId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar AnoInicioId!")]
    public Guid AnoInicioId { get; set; }
    
    public Guid? MesFimId { get; set; }
    public Guid? AnoFimId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Dia!")]
    public int Dia { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Valor!")]
    public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Descricao!")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar Frequencia!")]
    public EFrequenciaTransacao Frequencia { get; set; }
}

public class TransacaoRecorrenteAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    
    public Guid? MesFimId { get; set; }
    public Guid? AnoFimId { get; set; }
    
    public bool Ativo { get; set; }
}

public class TransacaoRecorrenteConsultarDTO
{
    public Guid? TenantId { get; set; }
    public Guid? CategoriaId { get; set; }
    public Guid? ContaId { get; set; }
    public bool? Ativo { get; set; }
}

public class TransacaoRecorrenteRemoverDTO
{
    public Guid Id { get; set; }
}

public class TransacaoRecorrenteRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid CategoriaId { get; set; }
    public Guid FormaDePagamentoId { get; set; }
    public Guid ContaId { get; set; }
    public Guid MesInicioId { get; set; }
    public Guid AnoInicioId { get; set; }
    public Guid? MesFimId { get; set; }
    public Guid? AnoFimId { get; set; }
    public int Dia { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public EFrequenciaTransacao Frequencia { get; set; }
    public bool Ativo { get; set; }
}

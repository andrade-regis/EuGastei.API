using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Conta;

public class ContaAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar NOME!")]
    public string Nome { get; set; }
}

public class ContaAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar NOME!")]
    public string Nome { get; set; }

    public bool Ativo { get; set; }
}

public class ContaConsultarDTO
{
    public Guid? TenantId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}

public class ContaRemoverDTO
{
    public Guid Id { get; set; }
}

public class ContaRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
}

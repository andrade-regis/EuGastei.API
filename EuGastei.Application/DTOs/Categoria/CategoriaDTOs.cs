using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Categoria;

public class CategoriaAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar TipoDeTransacaoId!")]
    public Guid TipoDeTransacaoId { get; set; }
    
    public Guid? CategoriaPaiId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar NOME!")]
    public string Nome { get; set; }
}

public class CategoriaAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar TipoDeTransacaoId!")]
    public Guid TipoDeTransacaoId { get; set; }
    
    public Guid? CategoriaPaiId { get; set; }
    
    [Required(ErrorMessage = "Obrigatório informar NOME!")]
    public string Nome { get; set; }

    public bool Ativo { get; set; }
}

public class CategoriaConsultarDTO
{
    public Guid? TenantId { get; set; }
    public Guid? TipoDeTransacaoId { get; set; }
    public Guid? CategoriaPaiId { get; set; }
    public string? Nome { get; set; }
    public bool? Ativo { get; set; }
}

public class CategoriaRemoverDTO
{
    public Guid Id { get; set; }
}

public class CategoriaRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid TipoDeTransacaoId { get; set; }
    public Guid? CategoriaPaiId { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
}

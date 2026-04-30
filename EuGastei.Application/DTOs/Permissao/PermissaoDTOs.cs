using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Permissao;

public class PermissaoAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }

    [Required(ErrorMessage = "Obrigatório informar Sigla!")]
    public string Sigla { get; set; }

    [Required(ErrorMessage = "Obrigatório informar Descrição!")]
    public string Descricao { get; set; }
}

public class PermissaoAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    public string? Sigla { get; set; }
    public string? Descricao { get; set; }
    public bool? Ativo { get; set; }
}

public class PermissaoConsultarDTO
{
    public Guid? TenantId { get; set; }
    public string? Sigla { get; set; }
    public bool? Ativo { get; set; }
}

public class PermissaoRemoverDTO
{
    public Guid Id { get; set; }
}

public class PermissaoRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Sigla { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
}

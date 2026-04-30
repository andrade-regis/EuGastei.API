using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.Perfil;

public class PerfilAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }

    [Required(ErrorMessage = "Obrigatório informar Nome!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Obrigatório informar Descrição!")]
    public string Descricao { get; set; }
}

public class PerfilAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public bool? Ativo { get; set; }
}

public class PerfilConsultarDTO
{
    public Guid? TenantId { get; set; }
    public string? Nome { get; set; }
}

public class PerfilRemoverDTO
{
    public Guid Id { get; set; }
}

public class PerfilRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace EuGastei.Application.DTOs.PerfilPermissao;

public class PerfilPermissaoAdicionarDTO
{
    [Required(ErrorMessage = "Obrigatório informar TenantId!")]
    public Guid TenantId { get; set; }

    [Required(ErrorMessage = "Obrigatório informar PerfilId!")]
    public Guid PerfilId { get; set; }

    [Required(ErrorMessage = "Obrigatório informar PermissaoId!")]
    public Guid PermissaoId { get; set; }
}

public class PerfilPermissaoAtualizarDTO
{
    [Required(ErrorMessage = "Obrigatório informar ID!")]
    public Guid Id { get; set; }
    public Guid? PerfilId { get; set; }
    public Guid? PermissaoId { get; set; }
}

public class PerfilPermissaoConsultarDTO
{
    public Guid? TenantId { get; set; }
    public Guid? PerfilId { get; set; }
    public Guid? PermissaoId { get; set; }
}

public class PerfilPermissaoRemoverDTO
{
    public Guid Id { get; set; }
}

public class PerfilPermissaoRespostaDTO
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid PerfilId { get; set; }
    public Guid PermissaoId { get; set; }
}

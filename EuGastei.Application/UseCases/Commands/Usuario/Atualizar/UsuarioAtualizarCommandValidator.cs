using FluentValidation;

namespace EuGastei.Application.UseCases.Commands.Usuario.Atualizar;

public class UsuarioAtualizarCommandValidator : AbstractValidator<UsuarioAtualizarCommand>
{
    public UsuarioAtualizarCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id é obrigatório");
    }
}
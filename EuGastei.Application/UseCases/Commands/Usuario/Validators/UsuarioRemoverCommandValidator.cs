using FluentValidation;

namespace EuGastei.Application.UseCases.Commands.Usuario.Validators;

public class UsuarioRemoverCommandValidator : AbstractValidator<UsuarioRemoverCommand>
{
    public UsuarioRemoverCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Obrigatório informar ID do Usuario");
    }
}
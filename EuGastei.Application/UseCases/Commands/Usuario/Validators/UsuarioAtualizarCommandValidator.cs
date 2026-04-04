using FluentValidation;

namespace EuGastei.Application.UseCases.Commands.Usuario.Validators;

public class UsuarioAtualizarCommandValidator : AbstractValidator<UsuarioAtualizarCommand>
{
    public UsuarioAtualizarCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Obrigatório informar ID do Usuario");

        When(x => x.Email is not null, () =>
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Obrigatório informar e-mail válido");
        });
    }
}
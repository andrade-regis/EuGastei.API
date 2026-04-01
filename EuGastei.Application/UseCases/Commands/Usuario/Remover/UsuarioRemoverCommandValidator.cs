using FluentValidation;

namespace EuGastei.Application.UseCases.Commands.Usuario.Remover;

public class UsuarioRemoverCommandValidator : AbstractValidator<UsuarioRemoverCommand>
{
    public UsuarioRemoverCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("O Id do usuário é obrigatório.");
    }
}
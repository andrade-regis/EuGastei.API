using FluentValidation;

namespace EuGastei.Application.UseCases.Commands.Usuario.Validators;

public class UsuarioAdicionarCommandValidator :  AbstractValidator<UsuarioAdicionarCommand>
{
    public UsuarioAdicionarCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório");
        
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress()
            .WithMessage("E-mail é obrigatório");
        
        RuleFor(x => x.Senha)
            .NotEmpty()
            .NotNull()
            .WithMessage("Senha é obrigatório");
    }
}
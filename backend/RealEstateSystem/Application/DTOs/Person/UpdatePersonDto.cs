using FluentValidation;

namespace RealEstateSystem.Application.DTOs.Person;

public sealed record UpdatePersonDto(string? Name, int? Age)
{
    public void ValidateAndThrow() => new Validator().ValidateAndThrow(this);

    sealed class Validator : AbstractValidator<UpdatePersonDto> {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(200)
                .WithMessage("O Nome deve ter ao menos 200 caracteres.");
            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Idade deve ser maior ou igual a 0.");
        }
    }
}

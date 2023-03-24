using FluentValidation;
using Movii.Api.BindingModels;

namespace Movii.Api.Validation
{
    public class CreateClientValidator: AbstractValidator<CreateClient>
    {
        public CreateClientValidator() {
            RuleFor(x => x.ClientId).NotNull();
            RuleFor(x => x.ClientName).NotNull();
            RuleFor(x => x.ClientLastName).NotNull();
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.ClientHistory).NotNull();
            RuleFor(x => x.ClientAddress).NotNull();
        }
    }

}

using FluentValidation;
using Movii.Api.BindingModels;
using Movii.IServices.Requests;

namespace Movii.Api.Validation;

public class UpdateClientAddressValidator : AbstractValidator<UpdateClientAddress>
{
    public UpdateClientAddressValidator()
    {
        RuleFor(x=>x.ClientAddress).NotEmpty();
    }
}
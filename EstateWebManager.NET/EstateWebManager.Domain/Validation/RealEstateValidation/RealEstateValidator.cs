using FluentValidation;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.Domain.Validation.RealEstateValidation
{
    public class RealEstateValidator : AbstractValidator<RealEstate>
    {
        public RealEstateValidator()
        {
            RuleFor(realEstate => realEstate.Title).NotEmpty();
            RuleFor(realEstate => realEstate.ContactName).NotEmpty();
            RuleFor(realEstate => realEstate.ContactPhone.Length).GreaterThan(6);
            RuleFor(realEstate => realEstate.TransactionType).NotEmpty();
            RuleFor(realEstate => realEstate.Price).GreaterThan(0);
            RuleFor(realEstate => realEstate.Currency).NotEmpty();
            RuleFor(realEstate => realEstate.Street).NotEmpty();
            RuleFor(realEstate => realEstate.ZipCode).NotEmpty();
        }
    }
}

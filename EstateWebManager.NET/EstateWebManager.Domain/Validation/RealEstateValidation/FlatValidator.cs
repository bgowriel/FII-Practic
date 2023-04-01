using FluentValidation;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.Domain.Validation.RealEstateValidation
{
    public class FlatValidator : AbstractValidator<Flat>
    {
        public FlatValidator()
        {
            RuleFor(flat => flat.BuiltUpArea).GreaterThan(0);
            RuleFor(flat => flat.Bedrooms).GreaterThan(0);
            RuleFor(flat => flat.Bathrooms).GreaterThan(0);
            RuleFor(flat => flat.AvailableStarting).NotNull();
        }
    }
}

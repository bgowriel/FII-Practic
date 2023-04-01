using FluentValidation;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.Domain.Validation.RealEstateValidation
{
    public class OfficeValidator : AbstractValidator<Office>
    {
        public OfficeValidator()
        {
            RuleFor(office => office.Rating).NotEmpty();
            RuleFor(office => office.BuiltUpArea).GreaterThan(0);
            RuleFor(office => office.AvailableStarting).NotNull();
        }
    }
}

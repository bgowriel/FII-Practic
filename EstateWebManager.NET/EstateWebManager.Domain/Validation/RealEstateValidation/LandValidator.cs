using FluentValidation;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.Domain.Validation.RealEstateValidation
{
    public class LandValidator : AbstractValidator<Land>
    {
        public LandValidator()
        {
            RuleFor(land => land.LandArea).GreaterThan(0);
            RuleFor(land => land.AvailableStarting).NotNull();
        }
    }
}

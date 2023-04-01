using FluentValidation;
using EstateWebManager.Domain.Models.RealEstateClasses;

namespace EstateWebManager.Domain.Validation.RealEstateValidation
{
    public class HouseValidator : AbstractValidator<House>
    {
        public HouseValidator()
        {
            RuleFor(house => house.YearBuilt).GreaterThan(1900);
            RuleFor(house => house.BuiltUpArea).GreaterThan(0);
            RuleFor(house => house.LandArea).GreaterThan(0);
            RuleFor(house => house.Floors).GreaterThan(0);
            RuleFor(house => house.Bedrooms).GreaterThan(0);
            RuleFor(house => house.Bathrooms).GreaterThan(0);
            RuleFor(house => house.AvailableStarting).NotNull();
        }
    }
}

using FluentValidation;
using EstateWebManager.Domain.Models;

namespace EstateWebManager.Domain.Validation
{
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            RuleFor(area => area.PhonePrefix).NotEmpty();
            RuleFor(area => area.City).NotEmpty();
            RuleFor(area => area.Country).NotEmpty();
        }
    }
}

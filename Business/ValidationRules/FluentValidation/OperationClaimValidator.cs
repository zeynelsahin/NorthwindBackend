using Core.Entities.Concete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator : AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(claim => claim.Name).NotEmpty();
        }
    }
}
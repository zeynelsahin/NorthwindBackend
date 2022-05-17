using Core.Entities.Concete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator: AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            
        }
    }
}
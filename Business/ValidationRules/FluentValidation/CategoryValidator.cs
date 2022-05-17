using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty();
            RuleFor(category => category.CategoryId).GreaterThan(0).When(category => category.CategoryId!=null);
            // RuleFor(category => category.CategoryId)
        }
    }
}
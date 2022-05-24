using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CompanyName).MaximumLength(40);
            RuleFor(customer => customer.ContactName).MaximumLength(30);
            RuleFor(customer => customer.ContactTitle).MaximumLength(30);
            RuleFor(customer => customer.Address).MaximumLength(60);
            RuleFor(customer => customer.City).MaximumLength(15);
            RuleFor(customer => customer.Region).MaximumLength(15);
            RuleFor(customer => customer.PostalCode).MaximumLength(10);
            RuleFor(customer => customer.Country).MaximumLength(15);
            RuleFor(customer => customer.Phone).MaximumLength(24);
            RuleFor(customer => customer.Fax).MaximumLength(24);


            //Boş geçilemez
            RuleFor(customer => customer.CompanyName).NotEmpty();
            RuleFor(customer => customer.ContactName).NotEmpty();
            RuleFor(customer => customer.ContactTitle).NotEmpty();
            RuleFor(customer => customer.Address).NotEmpty();
            RuleFor(customer => customer.City).NotEmpty();
            RuleFor(customer => customer.Region).NotEmpty();
            RuleFor(customer => customer.PostalCode).NotEmpty();
            RuleFor(customer => customer.Country).NotEmpty();
            RuleFor(customer => customer.Phone).NotEmpty();
            RuleFor(customer => customer.Fax).NotEmpty();
        }
    }
}
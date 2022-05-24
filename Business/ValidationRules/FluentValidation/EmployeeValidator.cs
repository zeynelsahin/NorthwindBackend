using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.LastName).MaximumLength(20);
            RuleFor(employee => employee.FirstName).MaximumLength(10);
            RuleFor(employee => employee.Title).MaximumLength(30);
            RuleFor(employee => employee.TitleOfCourtesy).MaximumLength(25);
            RuleFor(employee => employee.Address).MaximumLength(60);
            RuleFor(employee => employee.City).MaximumLength(15);
            RuleFor(employee => employee.Region).MaximumLength(15);
            RuleFor(employee => employee.PostalCode).MaximumLength(10);
            RuleFor(employee => employee.Country).MaximumLength(15);
            RuleFor(employee => employee.HomePhone).MaximumLength(24);
            RuleFor(employee => employee.Extension).MaximumLength(4);

            //RuleFor(employee => employee.EmployeeID).NotEmpty();
            RuleFor(employee => employee.LastName).NotEmpty();
            RuleFor(employee => employee.FirstName).NotEmpty();
            RuleFor(employee => employee.Title).NotEmpty();
            RuleFor(employee => employee.TitleOfCourtesy).NotEmpty();
            RuleFor(employee => employee.BirthDate).NotEmpty();
            RuleFor(employee => employee.HireDate).NotEmpty();
            RuleFor(employee => employee.Address).NotEmpty();
            RuleFor(employee => employee.City).NotEmpty();
            RuleFor(employee => employee.Region).NotEmpty();
            RuleFor(employee => employee.PostalCode).NotEmpty();
            RuleFor(employee => employee.Country).NotEmpty();
            RuleFor(employee => employee.HomePhone).NotEmpty();
            RuleFor(employee => employee.Extension).NotEmpty();
            //RuleFor(employee => employee.Photo).NotEmpty();
            RuleFor(employee => employee.Notes).NotEmpty();
            RuleFor(employee => employee.ReportsTo).GreaterThan(0);
            RuleFor(employee => employee.PhotoPath).NotEmpty();
        }
    }
}
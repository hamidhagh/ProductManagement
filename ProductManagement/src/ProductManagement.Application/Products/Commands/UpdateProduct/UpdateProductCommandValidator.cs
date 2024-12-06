using FluentValidation;
using ProductManagement.Application.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.ProduceDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("ProduceDate cannot be in the future.");

            RuleFor(x => x.ManufacturePhone)
            .Matches(@"^09\d{9}$").WithMessage("ManufacturePhone must be 11 digits and start with '09'.")
            .When(x => !string.IsNullOrEmpty(x.ManufacturePhone));

            RuleFor(x => x.ManufactureEmail)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.ManufactureEmail))
                .WithMessage("ManufactureEmail must be a valid email address.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.");
                //.Must(IsValidGuid).WithMessage("UserId must be a valid GUID.");
        }

        private bool IsValidGuid(string userId)
        {
            return Guid.TryParse(userId, out _);
        }
    }
}

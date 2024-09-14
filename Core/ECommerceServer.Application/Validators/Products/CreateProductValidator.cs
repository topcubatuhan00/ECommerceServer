using ECommerceServer.Application.ViewModels.ProductModels;
using FluentValidation;

namespace ECommerceServer.Application.Validators.Products;

public class CreateProductValidator : AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().NotNull()
            .WithMessage("Name is required")
        .MaximumLength(100).WithMessage("Name must be less than 100 characters")
        .MinimumLength(5).WithMessage("Name must be more than 5 characters");
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required")
            .Must(x => x >= 0).WithMessage("Price must be greater than or equal to 0");

        RuleFor(x => x.Stock)
            .NotEmpty()
            .WithMessage("Stock is required")
            .Must(x => x >= 0).WithMessage("Stock must be greater than or equal to 0");
    }
}

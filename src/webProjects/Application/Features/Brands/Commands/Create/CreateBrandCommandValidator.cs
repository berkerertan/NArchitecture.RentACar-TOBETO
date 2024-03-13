using Application.Features.Brands.Constants;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(b=>b.Name).NotEmpty().WithMessage(BrandsMessages.NameNotBlank);
        RuleFor(b=>b.Name).MinimumLength(2);
    }
}

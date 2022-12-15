namespace Memorabilia.Application.Validators.Memorabilia.Baseball;

public class BaseballValidator : AbstractValidator<SaveBaseball.Command>
{
    public BaseballValidator()
    {
        RuleFor(x => x.BrandId)
            .Must(x => x == Domain.Constants.Brand.Rawlings.Id)
            .When(x => x.BaseballTypeId.HasValue)
            .WithMessage("Brand must be Rawlings when there is a Baseball Type");
    }
}

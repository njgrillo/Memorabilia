namespace Memorabilia.Application.Validators.Memorabilia.Baseball;

public class BaseballValidator : AbstractValidator<SaveBaseball.Command>
{
    public BaseballValidator()
    {
        RuleFor(x => x)
            .Must(CanHaveAnniversary)
            .When(x => !x.Anniversary.IsNullOrEmpty())
            .WithName("Anniversary")
            .WithMessage("Cannot have Anniversary with this combination of Baseball Type, Brand, Level and Size.");

        RuleFor(x => x)
            .Must(CanHaveBaseballType)
            .When(x => x.BaseballTypeId.HasValue)
            .WithName("Baseball Type")
            .WithMessage("Can only have Baseball Type when Brand is Rawlings, Level is Professional and Size is Standard.");

        RuleFor(x => x)
            .Must(CanHaveCommissioner)
            .When(x => x.CommissionerId > 0)
            .WithName("Commissioner")
            .WithMessage("Cannot have Commissioner with the specified combination.");

        RuleFor(x => x)
            .Must(CanHaveGameDate)
            .When(x => x.GameDate.HasValue)
            .WithName("Game Style")
            .WithMessage("Game Style must be Game Issued or Game Used when Game Date is specified.");

        RuleFor(x => x)
            .Must(CanHavePresident)
            .When(x => x.LeaguePresidentId.HasValue)
            .WithName("President")
            .WithMessage("Cannot have President with the specified combination.");

        RuleFor(x => x)
            .Must(CanHaveYear)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Cannot have Year with this combination of Baseball Type, Brand, Level and Size.");

        RuleFor(x => x.Anniversary)
            .MaximumLength(5)
            .When(x => !x.Anniversary.IsNullOrEmpty())
            .WithName("Anniversary")
            .WithMessage("Anniversary cannot be more than 5 characters.");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithName("Brand")
            .WithMessage("Brand is required.");        

        RuleFor(x => x.LevelTypeId)
            .GreaterThan(0)
            .WithName("Level")
            .WithMessage("Level is required.");

        RuleFor(x => x.SizeId)
            .GreaterThan(0)
            .WithName("Size")
            .WithMessage("Size is required.");

        RuleFor(x => x.Year)
            .GreaterThanOrEqualTo(1950)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be greater than or equal to 1950.");

        RuleFor(x => x.Year)
            .LessThanOrEqualTo(DateTime.UtcNow.Year + 1)
            .When(x => x.Year.HasValue)
            .WithName("Year")
            .WithMessage("Year must be less than or equal to current year plus one.");
    }

    private static bool CanHaveAnniversary(SaveBaseball.Command command)
        => (Domain.Constants.BaseballType.Find(command.BaseballTypeId ?? 0)?.CanHaveAnniversary() ?? false) &&
           CanHaveBaseballType(command);

    private static bool CanHaveBaseballType(SaveBaseball.Command command)
    {
        var brand = Domain.Constants.Brand.Find(command.BrandId);
        var levelType = Domain.Constants.LevelType.Find(command.LevelTypeId);
        var size = Domain.Constants.Size.Find(command.SizeId);

        return brand == Domain.Constants.Brand.Rawlings &&
               levelType == Domain.Constants.LevelType.Professional &&
               size == Domain.Constants.Size.Standard;
    }

    private static bool CanHaveCommissioner(SaveBaseball.Command command)
        => (Domain.Constants.Brand.Find(command.BrandId)?.IsGameWorthlyBaseballBrand() ?? false) &&
           (Domain.Constants.BaseballType.Find(command.BaseballTypeId ?? 0)?.IsCommissionerType() ?? false);

    private static bool CanHaveGameDate(SaveBaseball.Command command)
    {
        var size = Domain.Constants.Size.Find(command.SizeId);

        return (Domain.Constants.BaseballType.Find(command.BaseballTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               (Domain.Constants.Brand.Find(command.BrandId)?.IsGameWorthlyBaseballBrand() ?? false) &&
               (Domain.Constants.GameStyleType.Find(command.GameStyleTypeId ?? 0)?.IsGameWorthly() ?? false) &&
               size == Domain.Constants.Size.Standard;
    }

    private static bool CanHavePresident(SaveBaseball.Command command)
        => (Domain.Constants.Brand.Find(command.BrandId)?.IsGameWorthlyBaseballBrand() ?? false) &&
           (Domain.Constants.BaseballType.Find(command.BaseballTypeId ?? 0)?.IsLeaguePresidentType() ?? false);

    private static bool CanHaveYear(SaveBaseball.Command command)
        => (Domain.Constants.BaseballType.Find(command.BaseballTypeId ?? 0)?.CanHaveYear() ?? false) &&
           CanHaveBaseballType(command);
}

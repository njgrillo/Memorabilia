using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Basketball;

public class BasketballProfileViewModel : SportProfileViewModel
{
    public BasketballProfileViewModel() { }

    public BasketballProfileViewModel(Person person) : base(person) { }

    public override string ChampionshipSummaryDisplayText => $"{Championships?.Count() ?? 0}x Finals Champion";

    public override string Debut => Service?.DebutDate.HasValue ?? false
        ? $"NBA Debut {Service.DebutDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public override string LastAppearance => Service?.LastAppearanceDate.HasValue ?? false
        ? $"Last NBA Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public override string NameHeader
    {
        get
        {
            var header = base.NameHeader;
            var hof = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevel == Domain.Constants.SportLeagueLevel.NationalBasketballAssociation);

            if (hof == null)
                return header;

            return $"{header} | HOF {hof.InductionYear}";
        }
    }
}

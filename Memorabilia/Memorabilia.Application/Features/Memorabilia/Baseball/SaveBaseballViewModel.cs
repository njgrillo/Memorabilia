using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class SaveBaseballViewModel : MemorabiliaItemEditViewModel
{
    public SaveBaseballViewModel() 
    {
        BrandId = Brand.Rawlings.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveBaseballViewModel(BaseballViewModel viewModel)
    {
        BaseballTypeAnniversary = viewModel.Baseball?.Anniversary;
        BaseballTypeId = viewModel.Baseball?.BaseballTypeId ?? 0;
        BaseballTypeYear = viewModel.Baseball?.Year;
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner?.CommissionerId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LeaguePresidentId = viewModel.Baseball?.LeaguePresidentId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public string BaseballTypeAnniversary { get; set; }

    public BaseballType BaseballType => BaseballType.Find(BaseballTypeId);

    public int BaseballTypeId { get; set; } = BaseballType.Official.Id;

    public int? BaseballTypeYear { get; set; }

    public Brand Brand => Brand.Find(BrandId);

    public int CommissionerId { get; set; }

    public bool DisplayBaseballType => BrandId == Brand.Rawlings.Id &&
                                       LevelTypeId == LevelType.Professional.Id &&
                                       SizeId == Size.Standard.Id;

    public bool DisplayBaseballTypeAnniversary 
        => DisplayBaseballType && BaseballType.CanHaveAnniversary();

    public bool DisplayBaseballTypeYear 
        => DisplayBaseballType && BaseballType.CanHaveYear();

    public bool DisplayCommissioner 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           (BaseballType?.IsCommissionerType() ?? false);

    public override bool DisplayGameDate 
        => DisplayGameStyleType &&
           (BaseballType?.IsGameWorthly() ?? false) && 
           (GameStyleType?.IsGameWorthly() ?? false);

    public override bool DisplayGameStyleType 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           SizeId == Size.Standard.Id;

    public bool DisplayLeaguePresident 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           (BaseballType?.IsLeaguePresidentType() ?? false);

    public override string ImageFileName
    {
        get
        {
            if (DisplayBaseballType && BaseballType != null)
                return $"{BaseballType.Name.Replace(" ", "")}.jpg";

            return Constant.ImageFileName.Baseball;
        }
    }

    public override ItemType ItemType => ItemType.Baseball;

    public League League
    {
        get
        {
            if (BaseballType == BaseballType.AmericanLeague)
                return League.AmericanLeague;

            if (BaseballType == BaseballType.NationalLeague)
                return League.NationalLeague;

            return null;
        }
    }

    public int LeaguePresidentId { get; set; }

    public override Sport Sport => Sport.Baseball;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;
}

namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class BaseballEditModel : MemorabiliaItemEditModel
{
    public BaseballEditModel() 
    {
        BrandId = Constant.Brand.Rawlings.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public BaseballEditModel(BaseballModel model)
    {
        BaseballTypeAnniversary = model.Baseball?.Anniversary;
        BaseballTypeId = model.Baseball?.BaseballTypeId ?? 0;
        BaseballTypeYear = model.Baseball?.Year;
        BrandId = model.Brand.BrandId;
        CommissionerId = model.Commissioner?.CommissionerId ?? 0;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LeaguePresidentId = model.Baseball?.LeaguePresidentId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();

        if (model.People.Any())
            Person = new PersonModel(model.People.First().Person);
    }

    public string BaseballTypeAnniversary { get; set; }

    public Constant.BaseballType BaseballType 
        => Constant.BaseballType.Find(BaseballTypeId);

    public int BaseballTypeId { get; set; } 
        = Constant.BaseballType.Official.Id;

    public int? BaseballTypeYear { get; set; }

    public Constant.Brand Brand 
        => Constant.Brand.Find(BrandId);

    public int CommissionerId { get; set; }

    public bool DisplayBaseballType 
        => BrandId == Constant.Brand.Rawlings.Id &&
           LevelTypeId == Constant.LevelType.Professional.Id &&
           SizeId == Constant.Size.Standard.Id;

    public bool DisplayBaseballTypeAnniversary 
        => DisplayBaseballType && 
           BaseballType.CanHaveAnniversary();

    public bool DisplayBaseballTypeYear 
        => DisplayBaseballType && 
           BaseballType.CanHaveYear();

    public bool DisplayCommissioner 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           (BaseballType?.IsCommissionerType() ?? false);

    public override bool DisplayGameDate 
        => DisplayGameStyleType &&
           (BaseballType?.IsGameWorthly() ?? false) && 
           (GameStyleType?.IsGameWorthly() ?? false);

    public override bool DisplayGameStyleType 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           SizeId == Constant.Size.Standard.Id;

    public bool DisplayLeaguePresident 
        => (Brand?.IsGameWorthlyBaseballBrand() ?? false) &&
           (BaseballType?.IsLeaguePresidentType() ?? false);

    public override string ImageFileName
        => DisplayBaseballType && BaseballType != null
            ? $"{BaseballType.Name.Replace(" ", "")}.jpg"
            : Constant.ImageFileName.Baseball;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Baseball;

    public Constant.League League
        => BaseballType == Constant.BaseballType.AmericanLeague
            ? Constant.League.AmericanLeague
            : Constant.League.NationalLeague;

    public int LeaguePresidentId { get; set; }

    public override Constant.Sport Sport 
        => Constant.Sport.Baseball;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.MajorLeagueBaseball;
}

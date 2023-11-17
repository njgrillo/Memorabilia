namespace Memorabilia.Application.Features.Memorabilia.HockeyStick;

public class HockeyStickEditModel : MemorabiliaItemEditModel
{
    public HockeyStickEditModel()
    { 
        BrandId = Constant.Brand.CCM.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Full.Id;
    }

    public HockeyStickEditModel(HockeyStickModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Any())
            Person = new PersonModel(model.People.First().Person);

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Full.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.HockeyStick;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.HockeyStick;

    public override Constant.Sport Sport 
        => Constant.Sport.Hockey;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalHockeyLeague;
}

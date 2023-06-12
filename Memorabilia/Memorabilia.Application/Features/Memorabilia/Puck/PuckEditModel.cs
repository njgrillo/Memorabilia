namespace Memorabilia.Application.Features.Memorabilia.Puck;

public class PuckEditModel : MemorabiliaItemEditModel
{
    public PuckEditModel() 
    { 
        BrandId = Constant.Brand.CCM.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public PuckEditModel(PuckModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Any())
            Person = model.People.First().Person.ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Standard.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.Puck;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Puck;

    public override Constant.Sport Sport 
        => Constant.Sport.Hockey;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalHockeyLeague;
}

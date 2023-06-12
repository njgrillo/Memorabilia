namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class PylonEditModel : MemorabiliaItemEditModel
{
    public PylonEditModel() 
    {
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public PylonEditModel(PylonModel model)
    {
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Pylon;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Pylon;

    public override Constant.Sport Sport 
        => Constant.Sport.Tennis;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalFootballLeague;
}

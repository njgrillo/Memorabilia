namespace Memorabilia.Application.Features.Memorabilia.Soccerball;

public class SoccerballEditModel : MemorabiliaItemEditModel
{
    public SoccerballEditModel() 
    {
        BrandId = Constant.Brand.Nike.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public SoccerballEditModel(SoccerballModel model)
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

    public override string ImageFileName 
        => Constant.ImageFileName.Soccerball;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Soccerball;

    public override Constant.Sport Sport 
        => Constant.Sport.Soccer;
}

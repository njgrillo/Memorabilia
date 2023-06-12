namespace Memorabilia.Application.Features.Memorabilia.WristBand;

public class WristBandEditModel : MemorabiliaItemEditModel
{
    public WristBandEditModel() 
    {
        BrandId = Constant.Brand.Adidas.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public WristBandEditModel(WristBandModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

        SportId = model.Sports
                       .Select(sport => sport.SportId)
                       .FirstOrDefault();

        if (model.People.Any())
            Person = model.People.First().Person.ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }           

    public override string ImageFileName 
        => Constant.ImageFileName.WristBand;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.WristBand;
}

namespace Memorabilia.Application.Features.Memorabilia.HeadBand;

public class HeadBandEditModel : MemorabiliaItemEditModel
{
    public HeadBandEditModel()
    {
        BrandId = Constant.Brand.None.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public HeadBandEditModel(HeadBandModel model)
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
            Person = new PersonModel(model.People.First().Person);

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override string ImageFileName 
        => Constant.ImageFileName.HeadBand;

    public override Constant.ItemType ItemType
        => Constant.ItemType.HeadBand;
}

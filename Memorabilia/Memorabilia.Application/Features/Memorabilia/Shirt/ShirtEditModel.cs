namespace Memorabilia.Application.Features.Memorabilia.Shirt;

public class ShirtEditModel : MemorabiliaItemEditModel
{
    public ShirtEditModel() 
    { 
        BrandId = Constant.Brand.Nike.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Large.Id;
    }

    public ShirtEditModel(ShirtModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        SportId = model.Sports
                       .Select(sport => sport.SportId)
                       .FirstOrDefault();

        if (model.People.Any())
            Person = new PersonModel(model.People.First().Person);

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Shirt;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Shirt;
}

namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public class TrunkEditModel : MemorabiliaItemEditModel
{
    public TrunkEditModel() 
    {
        BrandId = Constant.Brand.Everlast.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.None.Id;
    }

    public TrunkEditModel(TrunkModel model)
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
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Trunks;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Trunks;
}

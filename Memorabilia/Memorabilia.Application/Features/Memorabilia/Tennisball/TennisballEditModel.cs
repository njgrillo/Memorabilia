namespace Memorabilia.Application.Features.Memorabilia.Tennisball;

public class TennisballEditModel : MemorabiliaItemEditModel
{
    public TennisballEditModel() 
    { 
        BrandId = Constant.Brand.Wilson.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public TennisballEditModel(TennisballModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Any())
            Person = new PersonModel(model.People.First().Person);
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Tennisball;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Tennisball;

    public override Constant.Sport Sport 
        => Constant.Sport.Tennis;
}

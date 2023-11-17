namespace Memorabilia.Application.Features.Memorabilia.Golfball;

public class GolfballEditModel : MemorabiliaItemEditModel
{
    public GolfballEditModel()
    {
        BrandId = Constant.Brand.Titleist.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public GolfballEditModel(GolfballModel model)
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

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Standard.Id;

    public override string ImageFileName
        => Constant.ImageFileName.Golfball;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Golfball;

    public override Constant.Sport Sport 
        => Constant.Sport.Golf;
}

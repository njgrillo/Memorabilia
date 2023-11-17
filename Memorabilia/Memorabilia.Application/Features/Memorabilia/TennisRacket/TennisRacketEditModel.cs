namespace Memorabilia.Application.Features.Memorabilia.TennisRacket;

public class TennisRacketEditModel : MemorabiliaItemEditModel
{
    public TennisRacketEditModel() 
    { 
        BrandId = Constant.Brand.Nike.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public TennisRacketEditModel(TennisRacketModel model)
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
        => Constant.ImageFileName.TennisRacket;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.TennisRacket;

    public override Constant.Sport Sport 
        => Constant.Sport.Tennis;
}

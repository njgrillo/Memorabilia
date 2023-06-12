namespace Memorabilia.Application.Features.Memorabilia.Shoe;

public class ShoeEditModel : MemorabiliaItemEditModel
{
    public ShoeEditModel() 
    {
        BrandId = Constant.Brand.Nike.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public ShoeEditModel(ShoeModel model)
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
            Person = model.People.First().Person.ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Shoe;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Shoe;
}

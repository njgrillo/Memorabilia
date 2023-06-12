namespace Memorabilia.Application.Features.Memorabilia.Hat;

public class HatEditModel : MemorabiliaItemEditModel
{
    public HatEditModel()
    { 
        BrandId = Constant.Brand.NewEra.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Other.Id;
    }

    public HatEditModel(HatModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        SportId = model.Sports
                       .Select(x => x.SportId)
                       .FirstOrDefault();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override string ImageFileName 
        => Constant.ImageFileName.Hat;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Hat;
}

namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class GloveEditModel : MemorabiliaItemEditModel
{
    public GloveEditModel() 
    { 
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public GloveEditModel(GloveModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        GloveTypeId = model.Glove?.GloveTypeId ?? 0;
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
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Standard.Id;

    public int GloveTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Glove;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Glove;
}

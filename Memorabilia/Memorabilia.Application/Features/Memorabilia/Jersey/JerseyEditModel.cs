namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public class JerseyEditModel : MemorabiliaItemEditModel
{
    public JerseyEditModel() 
    { 
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public JerseyEditModel(JerseyModel model)
    {            
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        JerseyQualityTypeId = model.Jersey.JerseyQualityTypeId;
        JerseyStyleTypeId = model.Jersey.JerseyStyleTypeId;
        JerseyTypeId = model.Jersey.JerseyTypeId;
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
        => DisplayGameStyleType && 
           IsGameWorthly;

    public override bool DisplayGameStyleType 
        => JerseyQualityTypeId == Constant.JerseyQualityType.Authentic.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.ItemTypes;

    public bool IsGameWorthly
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Jersey;

    public int JerseyQualityTypeId { get; set; }

    public int JerseyStyleTypeId { get; set; }

    public int JerseyTypeId { get; set; } 
        = Constant.JerseyType.Stitched.Id;
}

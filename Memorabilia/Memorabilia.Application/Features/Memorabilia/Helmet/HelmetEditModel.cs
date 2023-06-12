namespace Memorabilia.Application.Features.Memorabilia.Helmet;

public class HelmetEditModel : MemorabiliaItemEditModel
{
    public HelmetEditModel()
    { 
        BrandId = Constant.Brand.Riddell.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Mini.Id;
    }

    public HelmetEditModel(HelmetModel model)
    {
        BrandId = model.Brand.BrandId;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        HelmetFinishId = model.Helmet.HelmetFinishId ?? 0;
        HelmetQualityTypeId = model.Helmet.HelmetQualityTypeId ?? 0;
        HelmetTypeId = model.Helmet.HelmetTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        SportIds = model.Sports
                        .Select(x => x.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();

        Throwback = model.Helmet.Throwback;
    }

    public bool CanEditHelmetQualityType { get; private set; }
        = true;

    public override bool DisplayGameDate 
        => IsGameWorthly && DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Full.Id;

    public bool DisplayHelmetFinish 
        => !IsGameWorthly;

    public bool DisplayHelmetQualityType 
        => Constant.Size.Find(SizeId) == Constant.Size.Full;

    public int HelmetFinishId { get; set; }

    public int HelmetQualityTypeId { get; set; }

    public int HelmetTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Helmet;

    public bool IsGameWorthly 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Helmet;

    public bool Throwback { get; set; }
}

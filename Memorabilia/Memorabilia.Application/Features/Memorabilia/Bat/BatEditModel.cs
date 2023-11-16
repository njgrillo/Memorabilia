namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class BatEditModel : MemorabiliaItemEditModel
{
    public BatEditModel() 
    {
        BrandId = Constant.Brand.Rawlings.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        SizeId = Constant.Size.Full.Id;
    }

    public BatEditModel(BatModel model)
    {
        BatTypeId = model.Bat?.BatTypeId ?? 0;
        BrandId = model.Brand.BrandId;
        ColorId = model.Bat?.ColorId ?? 0;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        Length = model.Bat?.Length ?? 0;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Any())
            Person = model.People
                          .First()
                          .Person
                          .ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams
                        .First()
                        .Team
                        .ToEditModel();
    }

    public int BatTypeId { get; set; } 
        = Constant.BatType.BigStick.Id;

    public int ColorId { get; set; } 
        = Constant.Color.Black.Id;

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Full.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.Bat;

    public override Constant.ItemType ItemType
        => Constant.ItemType.Bat;

    public int? Length { get; set; }

    public override Constant.Sport Sport 
        => Constant.Sport.Baseball;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.MajorLeagueBaseball;
}

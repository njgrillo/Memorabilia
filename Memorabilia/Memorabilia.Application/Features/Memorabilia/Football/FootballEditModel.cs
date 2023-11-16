namespace Memorabilia.Application.Features.Memorabilia.Football;

public class FootballEditModel : MemorabiliaItemEditModel
{
    public FootballEditModel() 
    { 
        BrandId = Constant.Brand.Wilson.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Full.Id;
    }

    public FootballEditModel(FootballModel model)
    {            
        BrandId = model.Brand.BrandId;
        CommissionerId = model.Commissioner?.CommissionerId ?? 0;
        FootballTypeId = model.Football?.FootballTypeId ?? 0;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
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

    public int CommissionerId { get; set; }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Full.Id;

    public int FootballTypeId { get; set; }
        = Constant.FootballType.Duke.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.Football;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Football;

    public override Constant.Sport Sport 
        => Constant.Sport.Football;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalFootballLeague;
}

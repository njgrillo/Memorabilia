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

    public FootballEditModel(FootballModel viewModel)
    {            
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner?.CommissionerId ?? 0;
        FootballTypeId = viewModel.Football?.FootballTypeId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.People.Any())
            Person = viewModel.People.First().Person.ToEditModel();

        if (viewModel.Teams.Any())
            Team = viewModel.Teams.First().Team.ToEditModel();
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

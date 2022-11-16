using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class SaveBasketballViewModel : MemorabiliaItemEditViewModel
{
    public SaveBasketballViewModel() 
    { 
        BrandId = Brand.Spalding.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveBasketballViewModel(BasketballViewModel viewModel)
    {
        BasketballTypeId = viewModel.Basketball?.BasketballTypeId ?? 0;
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner?.CommissionerId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public int BasketballTypeId { get; set; } = BasketballType.Official.Id;

    public int CommissionerId { get; set; }

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyleType;

    public override bool DisplayGameStyleType => SizeId == Size.Full.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.Basketball;

    public override ItemType ItemType => ItemType.Basketball;

    public override Sport Sport => Sport.Basketball;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalBasketballAssociation;
}

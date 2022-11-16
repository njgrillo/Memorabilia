using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class SaveBatViewModel : MemorabiliaItemEditViewModel
{
    public SaveBatViewModel() 
    {
        BrandId = Brand.Rawlings.Id;
        GameStyleTypeId = GameStyleType.None.Id;
        SizeId = Size.Full.Id;
    }

    public SaveBatViewModel(BatViewModel viewModel)
    {
        BatTypeId = viewModel.Bat?.BatTypeId ?? 0;
        BrandId = viewModel.Brand.BrandId;
        ColorId = viewModel.Bat?.ColorId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        Length = viewModel.Bat?.Length ?? 0;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public int BatTypeId { get; set; } = BatType.BigStick.Id;

    public int ColorId { get; set; } = Color.Black.Id;

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyleType;

    public override bool DisplayGameStyleType => SizeId == Size.Full.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.Bat;

    public override ItemType ItemType => ItemType.Bat;

    public int? Length { get; set; }

    public override Sport Sport => Sport.Baseball;

    public override SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;
}

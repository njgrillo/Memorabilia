using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class SavePlayingCardViewModel : MemorabiliaItemEditViewModel
{
    public SavePlayingCardViewModel()
    {
        SizeId = Size.Standard.Id;
    }

    public SavePlayingCardViewModel(PlayingCardViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault(); 

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.PlayingCard;

    public override ItemType ItemType => ItemType.PlayingCard;
}

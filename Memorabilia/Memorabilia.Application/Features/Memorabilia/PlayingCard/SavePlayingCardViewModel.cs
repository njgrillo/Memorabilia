using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class SavePlayingCardViewModel : SaveItemViewModel
{
    public SavePlayingCardViewModel() { }

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

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImagePath => Domain.Constants.ImagePath.PlayingCard;

    public override ItemType ItemType => ItemType.PlayingCard;

    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public int SportId { get; set; }

    public SaveTeamViewModel Team { get; set; }
}

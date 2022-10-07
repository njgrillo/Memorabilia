using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class SaveJerseyNumberViewModel : SaveItemViewModel
{
    public SaveJerseyNumberViewModel() { }

    public SaveJerseyNumberViewModel(JerseyNumberViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImagePath => Domain.Constants.ImagePath.JerseyNumber;

    public override ItemType ItemType => ItemType.JerseyNumber;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemType.JerseyNumber.Name} Details";

    public SavePersonViewModel Person { get; set; }

    public int SportId { get; set; }

    public SaveTeamViewModel Team { get; set; }
}

using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class SaveJerseyNumberViewModel : MemorabiliaItemEditViewModel
{
    public SaveJerseyNumberViewModel() { }

    public SaveJerseyNumberViewModel(JerseyNumberViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        Number = viewModel.Number;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

        if (viewModel.Teams.Any())
            Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
    }

    public override string ImageFileName => Constant.ImageFileName.JerseyNumber;

    public override ItemType ItemType => ItemType.JerseyNumber;

    public int? Number { get; set; }
}

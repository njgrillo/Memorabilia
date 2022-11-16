using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class SaveFirstDayCoverViewModel : MemorabiliaItemEditViewModel
{
    public SaveFirstDayCoverViewModel()
    { 
        SizeId = Size.Standard.Id;
    }

    public SaveFirstDayCoverViewModel(FirstDayCoverViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        Date = viewModel.FirstDayCover?.Date;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public DateTime? Date { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.FirstDayCover;

    public override ItemType ItemType => ItemType.FirstDayCover;
}

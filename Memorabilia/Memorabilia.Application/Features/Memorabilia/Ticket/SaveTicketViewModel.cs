using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public class SaveTicketViewModel : MemorabiliaItemEditViewModel
{
    public SaveTicketViewModel() 
    {
        GameStyleTypeId = GameStyleType.None.Id;
    }

    public SaveTicketViewModel(TicketViewModel viewModel)
    {
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Ticket;

    public override ItemType ItemType => ItemType.Ticket;
}

using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Book;

public class SaveBookViewModel : MemorabiliaItemEditViewModel
{
    public SaveBookViewModel() { }

    public SaveBookViewModel(BookViewModel viewModel)
    {
        Edition = viewModel.Book?.Edition; 
        HardCover = viewModel.Book?.HardCover ?? true;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        Publisher = viewModel.Book?.Publisher;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        Title = viewModel.Book?.Title;
    }

    public string Edition { get; set; }

    public bool HardCover { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Book;

    public override ItemType ItemType => ItemType.Book;

    public string Publisher { get; set; }

    public string Title { get; set; }
}

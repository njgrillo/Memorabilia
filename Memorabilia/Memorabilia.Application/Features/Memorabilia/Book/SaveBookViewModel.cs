using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Book;

public class SaveBookViewModel : SaveItemViewModel
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

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public string Edition { get; set; }

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HardCover { get; set; }

    public override string ImagePath => Domain.Constants.ImagePath.Book;

    public override ItemType ItemType => ItemType.Book;

    public List<SavePersonViewModel> People { get; set; } = new();

    public string Publisher { get; set; }

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();

    public string Title { get; set; }
}

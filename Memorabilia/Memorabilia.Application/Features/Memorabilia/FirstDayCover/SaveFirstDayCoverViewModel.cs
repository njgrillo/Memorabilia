using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class SaveFirstDayCoverViewModel : SaveItemViewModel
{
    public SaveFirstDayCoverViewModel() { }

    public SaveFirstDayCoverViewModel(FirstDayCoverViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        Date = viewModel.FirstDayCover?.Date;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public DateTime? Date { get; set; }

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImageFileName => Domain.Constants.ImageFileName.FirstDayCover;

    public override ItemType ItemType => ItemType.FirstDayCover;

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}

using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public class SaveMagazineViewModel : SaveItemViewModel
{
    public SaveMagazineViewModel() { }

    public SaveMagazineViewModel(MagazineViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Date = viewModel.Magazine.Date;
        Framed = viewModel.Magazine.Framed;
        Matted = viewModel.Magazine.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Magazine.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; }

    public DateTime? Date { get; set; }

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool Framed { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Magazine;

    public override ItemType ItemType => ItemType.Magazine;

    public bool Matted { get; set; }

    public int OrientationId { get; set; }

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}

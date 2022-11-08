using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class SavePhotoViewModel : SaveItemViewModel
{
    public SavePhotoViewModel() { }

    public SavePhotoViewModel(PhotoViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Framed = viewModel.Picture.Framed;
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        PhotoTypeId = viewModel.Picture.PhotoTypeId ?? 0;
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.None.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool Framed { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Photo;

    public override ItemType ItemType => ItemType.Photo;       
    
    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Orientation.Portrait.Id;

    public Orientation[] Orientations => Orientation.All;

    public List<SavePersonViewModel> People { get; set; } = new();

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
    public int PhotoTypeId { get; set; } = PhotoType.Glossy.Id;

    public PhotoType[] PhotoTypes => PhotoType.All;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; }

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}

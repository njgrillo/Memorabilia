using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class SavePhotoViewModel : MemorabiliaItemEditViewModel
{
    public SavePhotoViewModel() 
    { 
        BrandId = Brand.None.Id;
    }

    public SavePhotoViewModel(PhotoViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        PhotoTypeId = viewModel.Picture.PhotoTypeId ?? 0;
        SizeId = viewModel.Size.SizeId;
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string ImageFileName => Domain.Constants.ImageFileName.Photo;

    public override ItemType ItemType => ItemType.Photo;       
    
    public bool Matted { get; set; }

    public int OrientationId { get; set; } = Orientation.Portrait.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
    public int PhotoTypeId { get; set; } = PhotoType.Glossy.Id;
}

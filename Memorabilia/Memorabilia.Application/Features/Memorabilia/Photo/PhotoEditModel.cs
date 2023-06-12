namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class PhotoEditModel : MemorabiliaItemEditModel
{
    public PhotoEditModel() 
    { 
        BrandId = Constant.Brand.None.Id;
    }

    public PhotoEditModel(PhotoModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        Matted = viewModel.Picture.Matted;
        MemorabiliaId = viewModel.MemorabiliaId;
        OrientationId = viewModel.Picture.OrientationId;

        People = viewModel.People
                          .Select(person => person.Person.ToEditModel())
                          .ToList();

        PhotoTypeId = viewModel.Picture.PhotoTypeId ?? 0;
        SizeId = viewModel.Size.SizeId;

        SportIds = viewModel.Sports
                            .Select(sport => sport.SportId)
                            .ToList();

        Teams = viewModel.Teams
                         .Select(team => team.Team.ToEditModel())
                         .ToList();
    }

    public override string ImageFileName
        => Constant.ImageFileName.Photo;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Photo;       
    
    public bool Matted { get; set; }

    public int OrientationId { get; set; }
        = Constant.Orientation.Portrait.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
    public int PhotoTypeId { get; set; } 
        = Constant.PhotoType.Glossy.Id;
}

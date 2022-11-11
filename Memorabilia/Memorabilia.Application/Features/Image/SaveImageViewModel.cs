using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Image;

public class SaveImageViewModel : SaveViewModel
{
    public SaveImageViewModel() { }

    public SaveImageViewModel(ImageViewModel viewModel)
    {
        FileName = viewModel.FileName;
        Id = viewModel.Id;
        ImageTypeId = viewModel.ImageTypeId;
    }

    public SaveImageViewModel(Domain.Entities.Image image)
    {
        FileName = image.FileName;
        Id = image.Id;
        ImageTypeId = image.ImageTypeId;
    }

    public string FileName { get; set; }

    public ImageType ImageType => ImageType.Find(ImageTypeId);

    [Required]
    public int ImageTypeId { get; set; }

    public bool IsPrimary => ImageTypeId == ImageType.Primary.Id;

    [Required]
    public DateTime UploadDate { get; set; }

    public override string PageTitle => $"{(Id > 0 ? EditModeType.Update.Name : EditModeType.Add.Name)} Image";
}

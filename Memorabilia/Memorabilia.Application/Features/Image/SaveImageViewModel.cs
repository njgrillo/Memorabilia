using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Image
{
    public class SaveImageViewModel : SaveViewModel
    {
        public SaveImageViewModel() { }

        public SaveImageViewModel(ImageViewModel viewModel, string fileName)
        {
            FileName = fileName;
            FilePath = viewModel.FilePath;
            Id = viewModel.Id;
            ImageTypeId = viewModel.ImageTypeId;
        }

        public SaveImageViewModel(Domain.Entities.Image image)
        {
            FilePath = image.FilePath;
            Id = image.Id;
            ImageTypeId = image.ImageTypeId;
        }

        public string FileName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "File Path is too long.")]
        [MinLength(1, ErrorMessage = "File Path is too short.")]
        public string FilePath { get; set; }

        public ImageType ImageType => ImageType.Find(ImageTypeId);

        [Required]
        public int ImageTypeId { get; set; }

        public bool IsPrimary => ImageTypeId == Domain.Constants.ImageType.Primary.Id;

        [Required]
        public DateTime UploadDate { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Image";
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Image
{
    public class SaveImageViewModel : SaveViewModel
    {
        public SaveImageViewModel() { }

        public SaveImageViewModel(ImageViewModel viewModel)
        {
            FilePath = viewModel.FilePath;
            Id = viewModel.Id;
            ImageTypeId = viewModel.ImageTypeId;
        }

        [Required]
        [StringLength(500, ErrorMessage = "File Path is too long.")]
        [MinLength(1, ErrorMessage = "File Path is too short.")]
        public string FilePath { get; set; }

        [Required]
        public int ImageTypeId { get; set; }

        public bool IsPrimary => ImageTypeId == Domain.Constants.ImageType.Primary.Id;

        [Required]
        public DateTime UploadDate { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Image";
    }
}

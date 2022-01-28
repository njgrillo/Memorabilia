using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class SaveSportViewModel : SaveViewModel
    {
        public SaveSportViewModel() { }

        public SaveSportViewModel(SportViewModel viewModel)
        {
            AlternateName = viewModel.AlternateName;
            Id = viewModel.Id;
            //ImagePath = viewModel.ImagePath;
            Name = viewModel.Name;
        }

        [StringLength(50, ErrorMessage = "Alternate Name is too long.")]
        public string AlternateName { get; set; }

        [StringLength(200, ErrorMessage = "Image Path is too long.")]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Sport";
    }
}

using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Pewter
{
    public class SavePewterViewModel : SaveViewModel
    {
        public SavePewterViewModel() { }

        public SavePewterViewModel(PewterViewModel viewModel)
        {
            Id = viewModel.Id;
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Franchise is required.")]
        public int FranchiseId { get; set; }

        [Required]
        public string ImagePath { get; set; } = "wwwroot/images/imagenotavailable.png";

        public override string ItemTitle => "Pewter";

        public override string RoutePrefix => "Pewters";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Team is required.")]
        public int TeamId { get; set; }
    }
}

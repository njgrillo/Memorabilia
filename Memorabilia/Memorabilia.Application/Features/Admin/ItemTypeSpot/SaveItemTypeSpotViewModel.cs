using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeSpot
{
    public class SaveItemTypeSpotViewModel : SaveViewModel
    {
        public SaveItemTypeSpotViewModel() { }

        public SaveItemTypeSpotViewModel(ItemTypeSpotViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            SpotId = viewModel.SpotId;
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Spot";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
        public int SpotId { get; set; }        
    }
}

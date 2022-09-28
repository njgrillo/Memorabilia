namespace Memorabilia.Application.Features.Admin.ItemTypeSpots
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

        public override string ExitNavigationPath => "ItemTypeSpots";

        public string ImagePath => "images/spots.jpg";

        public override string ItemTitle => "Item Type Spot";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public Domain.Constants.ItemType[] ItemTypes => Domain.Constants.ItemType.All;

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} Item Type Spot";

        public override string RoutePrefix => "ItemTypeSpots";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
        public int SpotId { get; set; }        

        public Domain.Constants.Spot[] Spots => Domain.Constants.Spot.All;
    }
}

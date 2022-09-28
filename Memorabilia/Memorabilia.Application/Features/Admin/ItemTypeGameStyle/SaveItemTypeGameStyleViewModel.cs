namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class SaveItemTypeGameStyleViewModel : SaveViewModel
    {
        public SaveItemTypeGameStyleViewModel() { }

        public SaveItemTypeGameStyleViewModel(ItemTypeGameStyleViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            GameStyleTypeId = viewModel.GameStyleTypeId;
        }

        public override string ExitNavigationPath => "ItemTypeGameStyles";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public Domain.Constants.GameStyleType[] GameStyleTypes => Domain.Constants.GameStyleType.All;

        public string ImagePath => "images/gamestyletypes.jpg";

        public override string ItemTitle => "Item Type Game Style";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public Domain.Constants.ItemType[] ItemTypes => Domain.Constants.ItemType.All;

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Game Style";

        public override string RoutePrefix => "ItemTypeGameStyles";
    }
}

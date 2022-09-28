namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class SaveItemTypeLevelViewModel : SaveViewModel
    {
        public SaveItemTypeLevelViewModel() { }

        public SaveItemTypeLevelViewModel(ItemTypeLevelViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            LevelTypeId = viewModel.LevelTypeId;
        }

        public override string ExitNavigationPath => "ItemTypeLevels";

        public string ImagePath => "images/leveltypes.jpg";

        public override string ItemTitle => "Item Type Level";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public Domain.Constants.ItemType[] ItemTypes => Domain.Constants.ItemType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
        public int LevelTypeId { get; set; }

        public Domain.Constants.LevelType[] LevelTypes => Domain.Constants.LevelType.All;

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} Item Type Level";

        public override string RoutePrefix => "ItemTypeLevels";
    }
}

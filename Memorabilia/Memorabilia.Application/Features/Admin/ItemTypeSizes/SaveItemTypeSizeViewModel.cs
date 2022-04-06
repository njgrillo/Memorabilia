using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes
{
    public class SaveItemTypeSizeViewModel : SaveViewModel
    {
        public SaveItemTypeSizeViewModel() { }

        public SaveItemTypeSizeViewModel(ItemTypeSizeViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            SizeId = viewModel.SizeId;
        }

        public override string ExitNavigationPath => "ItemTypeSizes";

        public string ImagePath => "images/sizes.jpg";

        public override string ItemTitle => "Item Type Size";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public Domain.Constants.ItemType[] ItemTypes => Domain.Constants.ItemType.All;

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} Item Type Size";

        public override string RoutePrefix => "ItemTypeSizes";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Domain.Constants.Size[] Sizes => Domain.Constants.Size.All;
    }
}

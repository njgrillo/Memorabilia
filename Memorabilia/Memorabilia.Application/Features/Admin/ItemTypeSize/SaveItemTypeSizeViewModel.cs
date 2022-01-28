using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeSize
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

        [Required]
        public int ItemTypeId { get; set; }

        [Required]
        public int SizeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Size";
    }
}

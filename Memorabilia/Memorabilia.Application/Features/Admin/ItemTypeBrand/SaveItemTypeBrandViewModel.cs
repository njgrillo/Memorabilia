using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class SaveItemTypeBrandViewModel : SaveViewModel
    {
        public SaveItemTypeBrandViewModel() { }

        public SaveItemTypeBrandViewModel(ItemTypeBrandViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            BrandId = viewModel.BrandId;
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }        

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Brand";
    }
}

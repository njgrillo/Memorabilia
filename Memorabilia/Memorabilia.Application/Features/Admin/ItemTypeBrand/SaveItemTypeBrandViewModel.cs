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
        public int BrandId { get; set; }

        [Required]
        public int ItemTypeId { get; set; }        

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Brand";
    }
}

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

        public Domain.Constants.Brand[] Brands => Domain.Constants.Brand.All;

        public override string ExitNavigationPath => "ItemTypeBrands";

        public string ImagePath => "images/brands.jpg";

        public override string ItemTitle => "Item Type Brand";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }      
        
        public Domain.Constants.ItemType[] ItemTypes => Domain.Constants.ItemType.All;

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit" : "Add")} Item Type Brand";

        public override string RoutePrefix => "ItemTypeBrands";
    }
}

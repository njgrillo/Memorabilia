using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class SaveItemTypeSportViewModel : SaveViewModel
    {
        public SaveItemTypeSportViewModel() { }

        public SaveItemTypeSportViewModel(ItemTypeSportViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            SportId = viewModel.SportId;
        }

        public override string ItemTitle => "Item Type Sport";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }        

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Sport";

        public override string RoutePrefix => "ItemTypeSports";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
        public int SportId { get; set; }
    }
}

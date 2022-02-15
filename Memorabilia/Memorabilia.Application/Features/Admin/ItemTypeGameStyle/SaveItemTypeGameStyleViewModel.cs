using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Authentic Type";
    }
}

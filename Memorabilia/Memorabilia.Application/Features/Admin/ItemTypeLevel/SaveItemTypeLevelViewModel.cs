using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
        public int LevelTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Level";
    }
}

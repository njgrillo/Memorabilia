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

        [Required]
        public int ItemTypeId { get; set; }

        [Required]
        public int SportId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Sport";
    }
}

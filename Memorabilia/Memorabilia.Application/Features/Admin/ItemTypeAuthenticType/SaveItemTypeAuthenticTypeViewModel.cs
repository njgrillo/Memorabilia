using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class SaveItemTypeAuthenticTypeViewModel : SaveViewModel
    {
        public SaveItemTypeAuthenticTypeViewModel() { }

        public SaveItemTypeAuthenticTypeViewModel(ItemTypeAuthenticTypeViewModel viewModel)
        {
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId;
            AuthenticTypeId = viewModel.AuthenticTypeId;
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Authentic Type is required.")]
        public int AuthenticTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Item Type Authentic Type";
    }
}

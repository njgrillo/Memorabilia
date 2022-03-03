using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class SaveSpotViewModel : SaveViewModel
    {
        public SaveSpotViewModel() { }

        public SaveSpotViewModel(SpotViewModel viewModel)
        {
            AutographId = viewModel.AutographId;
            ItemType = ItemType.Find(viewModel.ItemTypeId);
            SpotId = viewModel.SpotId;
        }

        public int AutographId { get; set; }

        public virtual string ImagePath => "images/spots.png";

        public ItemType ItemType { get; set; }

        public string ItemTypeName => ItemType?.Name;

        public override string PageTitle => $"Edit Spot";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
        public int SpotId { get; set; }
    }
}

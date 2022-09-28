using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Spot
{
    public class SaveSpotViewModel : SaveViewModel
    {
        public SaveSpotViewModel() { }

        public SaveSpotViewModel(SpotViewModel viewModel)
        {
            AutographId = viewModel.AutographId;
            ItemType = ItemType.Find(viewModel.ItemTypeId);
            MemorabiliaId = viewModel.MemorabiliaId;
            SpotId = viewModel.SpotId;
        }

        public int AutographId { get; set; }

        public AutographStep AutographStep => AutographStep.Spot;

        public override string BackNavigationPath => $"Autographs/Authentications/Edit/{AutographId}";

        public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

        public override string ContinueNavigationPath => $"Autographs/Image/Edit/{AutographId}";

        public override EditModeType EditModeType => SpotId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public virtual string ImagePath => "images/spots.jpg";

        public ItemType ItemType { get; set; }

        public string ItemTypeName => ItemType?.Name;

        public int MemorabiliaId { get; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Add ? "Add" : "Edit")} Spot";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Spot is required.")]
        public int SpotId { get; set; }
    }
}

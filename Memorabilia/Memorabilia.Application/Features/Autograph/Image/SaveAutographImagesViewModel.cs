using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class SaveAutographImagesViewModel : SaveViewModel
    {
        public SaveAutographImagesViewModel() { }

        public SaveAutographImagesViewModel(List<AutographImage> images, 
                                            Domain.Constants.ItemType itemType, 
                                            int memorabiliaId,
                                            int autographId)
        {
            Images = images.Select(image => new SaveImageViewModel(image)).ToList();
            ItemType = itemType;
            MemorabiliaId = memorabiliaId;
            AutographId = autographId;
        }

        [Required]
        public int AutographId { get; set; }

        public AutographStep AutographStep => AutographStep.Image;

        public override string BackNavigationPath => CanHaveSpot 
            ? $"Autographs/Spot/Edit/{AutographId}" 
            : $"Autographs/Authentications/Edit/{AutographId}";

        public bool CanHaveSpot => Domain.Constants.ItemType.CanHaveSpot(ItemType);

        public override string ContinueNavigationPath => $"Autographs/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => Images.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public string ImagePath => "images/images.png";

        public List<SaveImageViewModel> Images { get; set; } = new();

        public Domain.Constants.ItemType ItemType { get; }

        public int MemorabiliaId { get; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Add ? "Add" : "Edit")} Image(s)";
    }
}

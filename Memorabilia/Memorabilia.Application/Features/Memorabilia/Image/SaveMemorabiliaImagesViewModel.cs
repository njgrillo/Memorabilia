using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Image
{
    public class SaveMemorabiliaImagesViewModel : SaveViewModel
    {
        public SaveMemorabiliaImagesViewModel() { }

        public SaveMemorabiliaImagesViewModel(List<Domain.Entities.MemorabiliaImage> images, string itemTypeName)
        {
            Images = images.Select(image => new SaveImageViewModel(image)).ToList();
            ItemTypeName = itemTypeName;
        }

        public override string BackNavigationPath => $"Memorabilia/{ItemTypeName}/Edit/{MemorabiliaId}";

        public override string ContinueNavigationPath => $"Autographs/Edit/{MemorabiliaId}/-1";

        public override EditModeType EditModeType => Images.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public List<SaveImageViewModel> Images { get; set; } = new();

        public string ImagePath => "images/images.png";

        public string ItemTypeName { get; }

        [Required]
        public int MemorabiliaId { get; set; }

        public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Image;

        public override string PageTitle => $"{(EditModeType == EditModeType.Add ? "Add" : "Edit")} Memorabilia Image(s)";
    }
}

using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Image;

public class SaveMemorabiliaImagesViewModel : SaveViewModel
{
    public SaveMemorabiliaImagesViewModel() { }

    public SaveMemorabiliaImagesViewModel(MemorabiliaItemModel memorabiliaItemViewModel)
    {
        AutographId = memorabiliaItemViewModel.HasAutographs ? memorabiliaItemViewModel.Autographs.First().Id : null;
        HasAutographs = memorabiliaItemViewModel.HasAutographs;
        HasMultipleAutographs = memorabiliaItemViewModel.AutographsCount > 1;
        Images = memorabiliaItemViewModel.Images.Select(image => new SaveImageViewModel(image)).ToList();
        ItemTypeName = memorabiliaItemViewModel.ItemTypeName;
        MemorabiliaId = memorabiliaItemViewModel.Id;
    }

    public int? AutographId { get; private set; }

    public string AutographNavigationPath 
        => $"Autographs/{EditModeType.Update.Name}/{MemorabiliaId}/{(AutographId.HasValue ? AutographId : "-1")}";

    public override string BackNavigationPath 
        => $"Memorabilia/{ItemTypeName}/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override string ContinueNavigationPath 
        => $"Autographs/{EditModeType.Update.Name}/{MemorabiliaId}/-1";

    public override EditModeType EditModeType 
        => Images.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public bool HasAutographs { get; private set; }

    public bool HasMultipleAutographs { get; private set; }

    public List<SaveImageViewModel> Images { get; set; } = new();

    public string ItemTypeName { get; }

    [Required]
    public int MemorabiliaId { get; set; }

    public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Image;

    public override string PageTitle => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Memorabilia Image(s)";
}

using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public class SaveItemViewModel : SaveViewModel
{   
    public override string ContinueNavigationPath => $"Memorabilia/Image/{EditModeType.Update.Name}/{MemorabiliaId}";       

    public virtual string ImageFileName { get; set; }

    public virtual ItemType ItemType { get; set; }

    [Required]
    public int MemorabiliaId { get; set; }

    public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Detail;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemType?.Name} Details";
}

namespace Memorabilia.Application.Features.Memorabilia;

public class ItemEditModel : EditModel
{   
    public override string ContinueNavigationPath 
        => $"Memorabilia/Image/{Constant.EditModeType.Update.Name}/{MemorabiliaId}";       

    public virtual string ImageFileName { get; set; }

    public virtual Constant.ItemType ItemType { get; set; }

    [Required]
    public int MemorabiliaId { get; set; }

    public Constant.MemorabiliaItemStep MemorabiliaItemStep 
        => Constant.MemorabiliaItemStep.Detail;

    public override string PageTitle
        => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} {ItemType?.Name} Details";

    public bool SavedSuccessfully { get; set; }
}

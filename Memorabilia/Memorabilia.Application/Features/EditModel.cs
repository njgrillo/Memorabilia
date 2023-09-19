namespace Memorabilia.Application.Features;

public class EditModel : Model
{   
    public virtual Constant.EditModeType EditModeType 
        => Id > 0 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;  

    public int Id { get; set; }

    public bool IsDeleted { get; set; }    

    public virtual bool IsModified { get; set; }

    public virtual bool IsNew 
        => Id == 0;

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update 
                ? Constant.EditModeType.Update.Name 
            : Constant.EditModeType.Add.Name)} {ItemTitle}";

    public FluentValidation.Results.ValidationResult ValidationResult { get; set; } 
        = new();

    public void MarkAsModified()
    {
        IsModified = true;
    }
}

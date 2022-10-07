using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features;

public class SaveViewModel : ViewModel
{   
    public virtual EditModeType EditModeType => Id > 0 ? EditModeType.Update : EditModeType.Add;

    public virtual string ExitButtonText { get; set; } = "Back";    

    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsModified => Id > 0 && !IsDeleted;

    public bool IsNew => Id == 0;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} {ItemTitle}";
}

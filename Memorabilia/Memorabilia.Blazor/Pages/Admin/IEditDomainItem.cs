namespace Memorabilia.Blazor.Pages.Admin;

public interface IEditDomainItem
{
    Task OnLoad();

    Task OnSave();
}

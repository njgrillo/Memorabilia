namespace Memorabilia.Blazor.Pages.Admin;

public interface IDeleteDomainItem
{
    Task OnDelete(DomainEditModel editModel);
}

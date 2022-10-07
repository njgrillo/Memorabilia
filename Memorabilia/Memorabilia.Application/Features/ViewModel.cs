namespace Memorabilia.Application.Features;

public abstract class ViewModel
{
    public virtual string BackNavigationPath { get; set; }

    public virtual string ContinueNavigationPath { get; set; }

    public virtual string ExitNavigationPath { get; set; } = "Admin/EditDomainItems";

    public virtual string ItemTitle { get; }

    public virtual string PageTitle { get; }

    public virtual string RoutePrefix { get; }
}

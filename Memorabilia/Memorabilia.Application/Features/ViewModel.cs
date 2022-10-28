namespace Memorabilia.Application.Features;

public abstract class ViewModel : IWithName, IWithValue<int>
{
    public virtual string BackNavigationPath { get; set; }

    public virtual string ContinueNavigationPath { get; set; }

    public virtual string ExitNavigationPath { get; set; } = "Admin/EditDomainItems";

    public virtual string ItemTitle { get; }

    public virtual string Name { get; set; }

    public virtual string PageTitle { get; }

    public virtual string RoutePrefix { get; }

    public virtual int Value { get; set; }
}

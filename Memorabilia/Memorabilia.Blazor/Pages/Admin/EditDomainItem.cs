namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditDomainItem<T> : CommandQuery where T : DomainItemConstant
{
    [Parameter]
    public string DomainImageRootPath { get; set; }

    [Parameter]
    public int Id { get; set; }

    protected virtual string DomainTypeName { get; } = type.Name.ToSentence();

    protected virtual string ImageFileName { get; } = $"{type.Name.ToPlural()}.jpg";

    protected virtual string NavigationPath { get; } = $"{type.Name.ToPlural()}";

    protected SaveDomainViewModel ViewModel { get; set; } 

    private static readonly Type type = typeof(T);

    protected override void OnInitialized()
    {
       ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImageFileName, NavigationPath);
    }

    protected async Task OnLoad(IRequest<DomainModel> request)
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(request),
                                            DomainTypeName,
                                            ImageFileName,
                                            NavigationPath);
    }

    protected async Task OnSave(ICommand command)
    {
        await CommandRouter.Send(command);
    }
}

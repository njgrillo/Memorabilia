#nullable disable

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditDomainItem<T> : CommandQuery where T : DomainItemConstant//<T>
{
    [Parameter]
    public int Id { get; set; }

    protected virtual string DomainTypeName { get; } = type.Name.ToSentence();//((object)typeof(T) as DomainItemConstant<T>)?.ObjectName;

    protected virtual string ImagePath { get; } = $"images/{type.Name}s.jpg";//((object)typeof(T) as DomainItemConstant<T>)?.ImagePath;

    protected virtual string NavigationPath { get; } = $"{type.Name}s";// ((object)typeof(T) as DomainItemConstant<T>)?.ObjectNamePlural;

    protected SaveDomainViewModel ViewModel { get; set; } 

    //private static readonly DomainItemConstant<T> item = ((object)type as DomainItemConstant<T>);

    private static readonly Type type = typeof(T);

    protected override void OnInitialized()
    {
       ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    protected async Task OnLoad(IRequest<DomainViewModel> request)
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(request),
                                            DomainTypeName,
                                            ImagePath,
                                            NavigationPath);
    }

    protected async Task OnSave(ICommand command)
    {
        await CommandRouter.Send(command);
    }
}

namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditDomainItem<T> 
    : CommandQuery where T : DomainItemConstant
{
    [Parameter]
    public int Id { get; set; }

    protected virtual string DomainTypeName { get; } 
        = type.Name.ToSentence();

    protected virtual string ImageFileName { get; } 
        = $"{type.Name.ToPlural()}.jpg";

    protected virtual string NavigationPath { get; } 
        = $"{type.Name.ToPlural()}";

    protected DomainEditModel EditModel { get; set; } 

    private static readonly Type type 
        = typeof(T);

    protected override void OnInitialized()
    {
        EditModel = new DomainEditModel(Id, 
                                        DomainTypeName, 
                                        ImageFileName, 
                                        NavigationPath);
    }

    protected async Task OnLoad(IRequest<Entity.DomainEntity> request)
    {
        if (Id == 0)
            return;

        EditModel = new DomainEditModel(new DomainModel(await Mediator.Send(request)),
                                        DomainTypeName,
                                        ImageFileName,
                                        NavigationPath);
    }

    protected async Task OnLoad(IRequest<DomainModel> request)
    {
        EditModel = new DomainEditModel(await Mediator.Send(request),
                                        DomainTypeName,
                                        ImageFileName,
                                        NavigationPath);
    }

    protected async Task OnSave(ICommand command)
    {
        await Mediator.Send(command);
    }
}

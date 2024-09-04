namespace Memorabilia.Blazor.Pages.MountRushmore;

public partial class ViewMountRushmores
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<MountRushmoreModel> Model
        = [];

    protected override async Task OnInitializedAsync()
    {
        Entity.MountRushmore[] mountRushmores
            = await Mediator.Send(new GetMountRushmores());

        Model = mountRushmores.Select(mountRushmore => new MountRushmoreModel(mountRushmore)).ToList();
    }

    protected async Task Delete(int id)
    {
        MountRushmoreModel deletedItem
            = Model.Single(mountRushmore => mountRushmore.Id == id);

        var model = new MountRushmoreEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveMountRushmore.Command(model));

        Model.Remove(deletedItem);

        Snackbar.Add("Mount Rushmore was deleted successfully!", Severity.Success);
    }
}

namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class ViewPewters 
    : ViewItem<PewtersModel, PewterModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Model = new PewtersModel(await QueryRouter.Send(new GetPewters()));
    }

    protected override async Task Delete(int id)
    {
        PewterModel deletedItem = Model.Pewters.Single(pewter => pewter.Id == id);

        var editModel = new PewterEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePewter(editModel));

        Model.Pewters.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(PewterModel model, string search)
        => search.IsNullOrEmpty() ||
           model.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}

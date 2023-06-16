namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class ViewPositions 
    : ViewItem<PositionsModel, PositionModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new PositionsModel(await QueryRouter.Send(new GetPositions()));
    }

    protected override async Task Delete(int id)
    {
        PositionModel deletedItem = Model.Positions.Single(position => position.Id == id);

        var editModel = new PositionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePosition(editModel));

        Model.Positions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(PositionModel model, string search)
        => search.IsNullOrEmpty() ||
           model.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
            model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}

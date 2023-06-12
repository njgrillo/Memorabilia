namespace Memorabilia.Blazor.Pages.Admin.Commissioners;

public partial class ViewCommissioners 
    : ViewItem<CommissionersModel, CommissionerModel>
{
    protected async Task OnLoad()
    {
        Model = new CommissionersModel(await QueryRouter.Send(new GetCommissioners()));
    }

    protected override async Task Delete(int id)
    {
        CommissionerModel deletedItem = Model.Commissioners.Single(Commissioner => Commissioner.Id == id);

        var editModel = new CommissionerEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveCommissioner(editModel));

        Model.Commissioners.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(CommissionerModel model, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && model?.BeginYear == year) ||
               (isYear && model?.EndYear == year) ||
               (model.Person != null &&
                model.Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}

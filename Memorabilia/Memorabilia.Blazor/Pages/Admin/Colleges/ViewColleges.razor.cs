namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class ViewColleges
    : ViewItem<CollegesModel, CollegeModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new CollegesModel(await Mediator.Send(new GetColleges()));
    }

    protected override async Task Delete(int id)
    {
        CollegeModel deletedItem = Model.Colleges.Single(College => College.Id == id);

        var editModel = new CollegeEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveCollege(editModel));

        Model.Colleges.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(CollegeModel model, string search)
    {
        return search.IsNullOrEmpty() ||
               model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}

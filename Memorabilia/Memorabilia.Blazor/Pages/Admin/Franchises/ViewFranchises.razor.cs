﻿namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class ViewFranchises 
    : ViewItem<FranchisesModel, FranchiseModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new FranchisesModel(await Mediator.Send(new GetFranchises()));
    }

    protected override async Task Delete(int id)
    {
        FranchiseModel deletedItem = Model.Franchises.Single(Franchise => Franchise.Id == id);

        var editModel = new FranchiseEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveFranchise(editModel));

        Model.Franchises.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(FranchiseModel model, string search)
    {
        bool isYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && model.FoundYear == year);
    }
}

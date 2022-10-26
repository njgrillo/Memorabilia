#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonAutoComplete : Autocomplete<PersonViewModel>
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private IEnumerable<PersonViewModel> People = Enumerable.Empty<PersonViewModel>();    

    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";
        People = (await QueryRouter.Send(new GetPeople())).People;
    }

    protected override string GetItemSelectedText(PersonViewModel item)
    {
        return item?.DisplayName;
    }

    protected override string GetItemText(PersonViewModel item)
    {
        return item?.DisplayName;
    }

    public override async Task<IEnumerable<PersonViewModel>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<PersonViewModel>();

        return await Task.FromResult(People.Where(person => person.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }
}

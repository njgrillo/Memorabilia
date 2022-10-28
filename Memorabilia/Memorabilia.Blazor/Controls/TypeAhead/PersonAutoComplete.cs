#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonAutoComplete : NamedEntityAutoComplete<SavePersonViewModel>
{
    [Parameter]
    public Sport Sport { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";

        if (!Items.Any())
            Items = (await QueryRouter.Send(new GetPeople(Sport?.Id ?? null))).People.Select(person => new SavePersonViewModel(person));
    }
}

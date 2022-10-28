namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonProfileAutoComplete : NamedEntityAutoComplete<PersonViewModel>
{
    protected override async Task OnInitializedAsync()
    {
        Label = "Person";
        Placeholder = "Search by name...";
        Items = (await QueryRouter.Send(new GetPeople())).People;
    }
}

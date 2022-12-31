namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAllStarEditor : ComponentBase
{
    [Parameter]
    public List<int> AllStarYears { get; set; } = new();

    private string _years;

    private void Add()
    {
        AllStarYears.AddRange(_years.ToIntArray());

        _years = string.Empty;
    }
}

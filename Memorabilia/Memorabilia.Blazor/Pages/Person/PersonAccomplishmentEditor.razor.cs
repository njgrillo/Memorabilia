namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAccomplishmentEditor
{
    [Parameter]
    public List<PersonAccomplishmentEditModel> Accomplishments { get; set; }
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }    

    protected List<PersonAccomplishmentEditModel> Items
        => Accomplishments.OrderBy(accomplishment => accomplishment.Year.HasValue)
                          .ThenBy(accomplishment => accomplishment.Year)
                          .ThenBy(accomplishment => accomplishment.Name)
                          .Where(accomplishment => !accomplishment.IsDeleted)
                          .ToList();

    protected PersonAccomplishmentEditModel Model 
        = new();

    private string _search;
    private string _years;

    private void Add()
    {
        if (Model.AccomplishmentType == null)
            return;

        int[] years = _years.ToIntArray();

        if (years.IsNullOrEmpty())
        {
            var accomplishment = new PersonAccomplishmentEditModel(Model.AccomplishmentType, date: Model.Date);

            Accomplishments.Add(accomplishment);           
        }
        else
        {
            Accomplishments.AddRange(years.Select(year => new PersonAccomplishmentEditModel(Model.AccomplishmentType, year: year)));
        }        

        Model = new();

        _years = string.Empty;
    }

    private bool Filter(PersonAccomplishmentEditModel accomplishment)
        => accomplishment.Search(_search);
}
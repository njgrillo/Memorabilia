namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAccomplishmentEditor
{
    [Parameter]
    public List<PersonAccomplishmentEditModel> Accomplishments { get; set; }
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected bool IsDateAccomplishment 
        => Model.AccomplishmentType?.IsDateAccomplishment() ?? false;

    protected bool IsYearAccomplishment 
        => Model.AccomplishmentType?.IsYearAccomplishment() ?? false;

    protected List<PersonAccomplishmentEditModel> Items
        => Accomplishments.OrderBy(accomplishment => accomplishment.Year.HasValue)
                          .ThenBy(accomplishment => accomplishment.Year)
                          .ThenBy(accomplishment => accomplishment.Name)
                          .Where(accomplishment => !accomplishment.IsDeleted)
                          .ToList();

    protected PersonAccomplishmentEditModel Model 
        = new();

    private string _years;

    private void Add()
    {
        if (Model.AccomplishmentType == null)
            return;

        int[] years = _years.ToIntArray();

        if (years.IsNullOrEmpty())
        {
            var accomplishment = new PersonAccomplishmentEditModel()
            {
                AccomplishmentType = Model.AccomplishmentType
            };

            if (Model.Date.HasValue)
                accomplishment.Date = Model.Date;

            Accomplishments.Add(accomplishment);           
        }
        else
        {
            foreach (int year in years)
            {
                Accomplishments.Add(new PersonAccomplishmentEditModel() { AccomplishmentType = Model.AccomplishmentType, Year = year });
            }
        }        

        Model = new();
        _years = string.Empty;
    }
}
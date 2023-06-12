namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAccomplishmentEditor
{
    [Parameter]
    public List<PersonAccomplishmentEditModel> Accomplishments { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected bool IsDateAccomplishment 
        => _viewModel.AccomplishmentType?.IsDateAccomplishment() ?? false;

    protected bool IsYearAccomplishment 
        => _viewModel.AccomplishmentType?.IsYearAccomplishment() ?? false;

    protected List<PersonAccomplishmentEditModel> Items
        => Accomplishments.OrderBy(accomplishment => accomplishment.Year.HasValue)
                          .ThenBy(accomplishment => accomplishment.Year)
                          .ThenBy(accomplishment => accomplishment.Name)
                          .Where(accomplishment => !accomplishment.IsDeleted)
                          .ToList();

    private PersonAccomplishmentEditModel _viewModel = new();
    private string _years;

    private void Add()
    {
        if (_viewModel.AccomplishmentType == null)
            return;

        var years = _years.ToIntArray();

        if (!years.Any())
        {
            var accomplishment = new PersonAccomplishmentEditModel()
            {
                AccomplishmentType = _viewModel.AccomplishmentType
            };

            if (_viewModel.Date.HasValue)
                accomplishment.Date = _viewModel.Date;

            Accomplishments.Add(accomplishment);           
        }
        else
        {
            foreach (var year in years)
            {
                Accomplishments.Add(new PersonAccomplishmentEditModel() { AccomplishmentType = _viewModel.AccomplishmentType, Year = year });
            }
        }        

        _viewModel = new();
        _years = string.Empty;
    }
}
namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAccomplishmentEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected bool IsDateAccomplishment => AccomplishmentType.IsDateAccomplishment(_viewModel.AccomplishmentType?.Id ?? 0);

    protected bool IsYearAccomplishment => AccomplishmentType.IsYearAccomplishment(_viewModel.AccomplishmentType?.Id ?? 0);

    private SavePersonAccomplishmentViewModel _viewModel = new();
    private string _years;

    private void Add()
    {
        var years = _years.ToIntArray();

        if (!years.Any())
        {
            var accomplishment = new SavePersonAccomplishmentViewModel()
            {
                AccomplishmentType = _viewModel.AccomplishmentType
            };

            if (_viewModel.Date.HasValue)
                accomplishment.Date = _viewModel.Date;

            Accomplishments.Add(accomplishment);           
        }
        else
        {
            foreach (var year in _years.ToIntArray())
            {
                Accomplishments.Add(new SavePersonAccomplishmentViewModel() { AccomplishmentType = _viewModel.AccomplishmentType, Year = year });
            }
        }        

        _viewModel = new();
        _years = string.Empty;
    }
}
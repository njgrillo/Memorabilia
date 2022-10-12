#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAwardEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAwardViewModel> Awards { get; set; } = new();

    [Parameter]
    public AwardType[] AwardTypes { get; set; } = AwardType.All;

    private SavePersonAwardViewModel _viewModel = new();
    private string _years;

    private void Add()
    {
        foreach (var year in _years.ToIntArray())
        {
            Awards.Add(new SavePersonAwardViewModel() { AwardTypeId = _viewModel.AwardTypeId, Year = year });
        }

        _viewModel = new SavePersonAwardViewModel();
        _years = string.Empty;
    }

    private void Remove(int awardTypeId, int year)
    {
        var award = Awards.SingleOrDefault(award => award.AwardTypeId == awardTypeId && award.Year == year);

        if (award == null)
            return;

        award.IsDeleted = true;
    }
}

namespace Memorabilia.Application.Features.Tools.Shared.LifeDates;

public class LifeDatesViewModel : Model
{
    public LifeDatesViewModel() { }

    public LifeDatesViewModel(
        Entity.Person[] persons,
        Constant.Sport sport,
        PageInfoResult pageInfo)
    {
        PageInfo = pageInfo;
        Persons = persons.Select(person => new LifeDateViewModel(person, sport));
        Sport = sport;
    }

    public IEnumerable<LifeDateViewModel> Persons { get; set; }
        = [];

    public Constant.Sport Sport { get; set; }
}

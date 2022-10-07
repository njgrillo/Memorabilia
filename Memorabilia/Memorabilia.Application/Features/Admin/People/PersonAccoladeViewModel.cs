using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class PersonAccoladeViewModel
{
    private readonly Person _person;

    public PersonAccoladeViewModel() { }

    public PersonAccoladeViewModel(Person person)
    {
        _person = person;
    }

    public List<PersonAccomplishment> Accomplishments => _person.Accomplishments;

    public List<AllStar> AllStars => _person.AllStars;

    public List<PersonAward> Awards => _person.Awards;

    public List<CareerRecord> CareerRecords => _person.CareerRecords;

    public List<Leader> Leaders => _person.Leaders;

    public int PersonId => _person.Id;

    public List<RetiredNumber> RetiredNumbers => _person.RetiredNumbers;

    public List<SingleSeasonRecord> SingleSeasonRecords => _person.SingleSeasonRecords;

    public List<PersonSport> Sports => _person.Sports;
}

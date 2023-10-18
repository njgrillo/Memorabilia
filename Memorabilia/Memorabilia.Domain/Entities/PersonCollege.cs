namespace Memorabilia.Domain.Entities;

public class PersonCollege : DomainIdEntity
{
    public PersonCollege() { }

    public PersonCollege(int personId, int collegeId, int? beginYear, int? endYear)
    {
        PersonId = personId;
        CollegeId = collegeId;
        BeginYear = beginYear;
        EndYear = endYear;
    }

    public int? BeginYear { get; private set; }

    public int CollegeId { get; private set; }

    public int? EndYear { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }        

    public void Set(int collegeId, int? beginYear, int? endYear)
    {
        CollegeId = collegeId;
        BeginYear = beginYear;
        EndYear = endYear;
    }
}

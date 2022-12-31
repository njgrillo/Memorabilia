namespace Memorabilia.Domain.Entities;

public class CollegeHallOfFame : Framework.Library.Domain.Entity.DomainEntity
{
    public CollegeHallOfFame() { }

    public CollegeHallOfFame(int personId, int collegeId, int sportId, int? year)
    {
        PersonId = personId;
        CollegeId = collegeId;
        SportId = sportId;
        Year = year;
    }

    public virtual College College { get; private set; }

    public int CollegeId { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public virtual Sport Sport { get; private set; }

    public int SportId { get; private set; }

    public int? Year { get; private set; }

    public void Set(int collegeId, int sportId, int? year)
    {
        CollegeId = collegeId;
        SportId = sportId;
        Year = year;
    }
}

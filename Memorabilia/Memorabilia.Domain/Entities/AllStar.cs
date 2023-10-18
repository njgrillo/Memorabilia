namespace Memorabilia.Domain.Entities;

public class AllStar : DomainIdEntity
{
    public AllStar() { }

    public AllStar(int personId, int sportId, int? sportLeagueLevelId, int year)
    {
        PersonId = personId;
        Year = year;
        SportId = sportId;
        SportLeagueLevelId = sportLeagueLevelId;
    }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int SportId { get; private set; }

    public int? SportLeagueLevelId { get; private set; }

    public int Year { get; private set; }

    public void Set(int sportId, int? sportLeagueLevelId, int year)
    {
        SportId = sportId;
        Year = year;
        SportLeagueLevelId = sportLeagueLevelId;
    }
}

namespace Memorabilia.Domain.Entities;

public class CollegeHallOfFame : Entity
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

    public bool Filter(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
               (isNumeric && Year.HasValue && Year.Value == year) ||
               (College is not null && College.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (Sport is not null && Sport.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public void Set(int collegeId, int sportId, int? year)
    {
        CollegeId = collegeId;
        SportId = sportId;
        Year = year;
    }
}

namespace Memorabilia.Domain.Entities;

public class Draft : Entity
{
    public Draft() { }

    public Draft(int personId, int franchiseId, int year, int round, int? pick, int? overall)
    {
        PersonId = personId;
        FranchiseId = franchiseId;
        Year = year;
        Round = round;
        Pick = pick;
        Overall = overall;
    }

    public virtual Franchise Franchise { get; private set; }

    public int FranchiseId { get; private set; }

    public int? Overall { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public int? Pick { get; private set; }

    public int Round { get; private set; }

    public int Year { get; private set; }

    public bool Filter(string search)
    {
        bool isNumberic = int.TryParse(search, out int value);

        return search.IsNullOrEmpty() ||
               (isNumberic && Overall.HasValue && Overall.Value == value) ||
               (isNumberic && Pick.HasValue && Pick.Value == value) ||
               (isNumberic && Round == value) ||
               (isNumberic && Year == value) ||
               (Franchise is not null && Franchise.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (Person is not null && Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (Person is not null && Person.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public void Set(int franchiseId, int year, int round, int? pick, int? overall)
    {
        FranchiseId = franchiseId;
        Year = year;
        Round = round;
        Pick = pick;
        Overall = overall;
    }
}

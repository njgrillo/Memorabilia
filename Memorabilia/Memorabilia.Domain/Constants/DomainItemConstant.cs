namespace Memorabilia.Domain.Constants;

public abstract class DomainItemConstant
{
    public string Abbreviation { get; }

    public int Id { get; }

    public string Name { get; }

    public DomainItemConstant(int id, string name, string abbreviation = null)
    {
        Id = id;
        Name = name;
        Abbreviation = abbreviation;
    }

    public override string ToString()
    {
        return !Abbreviation.IsNullOrEmpty() ? Abbreviation : Name;
    }
}

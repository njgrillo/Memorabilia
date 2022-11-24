namespace Memorabilia.Domain.Constants;

public abstract class Filter<T>
{
    public virtual string Name { get; private init; }

    protected Filter(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}

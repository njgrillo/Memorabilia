namespace Memorabilia.Domain;

public interface IWithValue<T>
{
    T Value { get; }
}

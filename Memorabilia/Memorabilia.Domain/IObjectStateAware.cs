namespace Memorabilia.Domain;

public interface IObjectStateAware
{
    ObjectState ObjectState { get; }
}

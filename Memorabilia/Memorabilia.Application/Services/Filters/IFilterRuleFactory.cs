namespace Memorabilia.Application.Services.Filters;

public interface IFilterRuleFactory<T>
{
    List<IFilterRule<T>> Rules { get; }
}

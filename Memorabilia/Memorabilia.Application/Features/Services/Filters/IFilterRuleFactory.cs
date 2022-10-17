namespace Memorabilia.Application.Features.Services.Filters;

public interface IFilterRuleFactory<T>
{
    List<IFilterRule<T>> Rules { get; }
}

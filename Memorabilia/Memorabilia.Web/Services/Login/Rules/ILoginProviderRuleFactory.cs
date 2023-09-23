namespace Memorabilia.Web.Services.Login.Rules;

public interface ILoginProviderRuleFactory
{
    List<ILoginProviderRule> Rules { get; }
}

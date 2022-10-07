namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class ProfileRuleFactory : IProfileRuleFactory
{
    private readonly List<IProfileRule> _rules = new ();

    public ProfileRuleFactory()
    {
        _rules.Add(new BaseballProfileRule());
    }

    public List<IProfileRule> Rules => _rules;
}

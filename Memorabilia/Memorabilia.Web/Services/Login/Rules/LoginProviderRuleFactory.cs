namespace Memorabilia.Web.Services.Login.Rules;

public class LoginProviderRuleFactory : ILoginProviderRuleFactory
{
    private readonly IMediator _mediator;

    private readonly List<ILoginProviderRule> _rules
        = [];

    public LoginProviderRuleFactory(IMediator mediator)
    {
        _mediator = mediator;

        _rules.Add(new GoogleLoginProviderRule(_mediator));
        _rules.Add(new MetaLoginProviderRule());
        _rules.Add(new MicrosoftLoginProviderRule(_mediator));
        _rules.Add(new XLoginProviderRule(_mediator));
    }

    public List<ILoginProviderRule> Rules
        => _rules;
}

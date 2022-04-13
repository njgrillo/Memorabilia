using System.Collections.Generic;

namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules
{
    public interface IProfileRuleFactory
    {
        List<IProfileRule> Rules { get; }
    }
}

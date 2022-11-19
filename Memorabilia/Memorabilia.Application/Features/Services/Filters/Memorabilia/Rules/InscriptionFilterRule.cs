﻿namespace Memorabilia.Application.Features.Services.Filters.Autographs.Rules;

public class InscriptionFilterRule : IFilterRule<Domain.Entities.Memorabilia>
{
    private bool _hasInscriptions;

    public bool Applies(FilterItemEnum filterItem, object value)
    {
        if (filterItem != FilterItemEnum.AutographInscription)
            return false;

        _hasInscriptions = (bool)value;

        return _hasInscriptions;
    }

    public Expression<Func<Domain.Entities.Memorabilia, bool>> GetExpression()
    {
        return item => item.Autographs.Any(autograph => autograph.Inscriptions.Count > 0);
    }
}

﻿namespace Memorabilia.Repository.Implementations;

public class ContextLoader : IContextLoader
{
    private readonly DomainContext _domainContext;
    private readonly MemorabiliaContext _memorabiliaContext;

    public ContextLoader(DomainContext domainContext, MemorabiliaContext memorabiliaContext)
    {
        _domainContext = domainContext;
        _memorabiliaContext= memorabiliaContext;
    }

    public Task Load()
    {
        _domainContext.Set<Domain.Entities.AccomplishmentType>().Where(t => 1 == 0).Load();
        _memorabiliaContext.Set<Domain.Entities.Memorabilia>().Where(t => 1 == 0).Load();

        return Task.CompletedTask;
    }
}

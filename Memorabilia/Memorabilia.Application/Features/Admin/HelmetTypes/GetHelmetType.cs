﻿namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetHelmetType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetHelmetType query)
            => await _helmetTypeRepository.Get(query.Id);
    }
}

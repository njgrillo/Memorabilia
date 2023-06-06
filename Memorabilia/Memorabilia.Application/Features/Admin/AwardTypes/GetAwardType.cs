﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetAwardType, DomainModel>
    {
        private readonly IDomainRepository<AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetAwardType query)
        {
            return new DomainModel(await _awardTypeRepository.Get(query.Id));
        }
    }
}

using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetAwardType, DomainViewModel>
    {
        private readonly IDomainRepository<AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetAwardType query)
        {
            return new DomainViewModel(await _awardTypeRepository.Get(query.Id));
        }
    }
}

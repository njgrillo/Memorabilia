using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypeQuery(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetAccomplishmentTypeQuery, DomainViewModel>
    {
        private readonly IDomainRepository<AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetAccomplishmentTypeQuery query)
        {
            return new DomainViewModel(await _accomplishmentTypeRepository.Get(query.Id));
        }
    }
}

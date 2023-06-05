namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetAccomplishmentType, DomainViewModel>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetAccomplishmentType query)
        {
            return new DomainViewModel(await _accomplishmentTypeRepository.Get(query.Id));
        }
    }
}

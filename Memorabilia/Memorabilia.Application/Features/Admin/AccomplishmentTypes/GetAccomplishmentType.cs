namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetAccomplishmentType, DomainModel>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetAccomplishmentType query)
        {
            return new DomainModel(await _accomplishmentTypeRepository.Get(query.Id));
        }
    }
}

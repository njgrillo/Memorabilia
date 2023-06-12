namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentType(int Id) : IQuery<Entity.AccomplishmentType>
{
    public class Handler : QueryHandler<GetAccomplishmentType, Entity.AccomplishmentType>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<Entity.AccomplishmentType> Handle(GetAccomplishmentType query)
            => await _accomplishmentTypeRepository.Get(query.Id);
    }
}

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

public record GetAccomplishmentTypes() : IQuery<Entity.AccomplishmentType[]>
{
    public class Handler : QueryHandler<GetAccomplishmentTypes, Entity.AccomplishmentType[]>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<Entity.AccomplishmentType[]> Handle(GetAccomplishmentTypes query)
            => (await _accomplishmentTypeRepository.GetAll())
                    .ToArray();
    }
}

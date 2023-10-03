namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAccomplishmentType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetAccomplishmentType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.AccomplishmentType> _accomplishmentTypeRepository;

        public Handler(IDomainRepository<Entity.AccomplishmentType> accomplishmentTypeRepository)
        {
            _accomplishmentTypeRepository = accomplishmentTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetAccomplishmentType query)
            => await _accomplishmentTypeRepository.Get(query.Id);
    }
}

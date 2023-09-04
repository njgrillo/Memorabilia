namespace Memorabilia.Application.Features.Admin.AwardTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAwardType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetAwardType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Entity.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetAwardType query)
            => await _awardTypeRepository.Get(query.Id);
    }
}

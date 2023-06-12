namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardType(int Id) : IQuery<Entity.AwardType>
{
    public class Handler : QueryHandler<GetAwardType, Entity.AwardType>
    {
        private readonly IDomainRepository<Entity.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Entity.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<Entity.AwardType> Handle(GetAwardType query)
            => await _awardTypeRepository.Get(query.Id);
    }
}

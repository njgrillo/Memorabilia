namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardTypes() : IQuery<Entity.AwardType[]>
{
    public class Handler : QueryHandler<GetAwardTypes, Entity.AwardType[]>
    {
        private readonly IDomainRepository<Entity.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Entity.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<Entity.AwardType[]> Handle(GetAwardTypes query)
            => (await _awardTypeRepository.GetAll()).ToArray();
    }
}

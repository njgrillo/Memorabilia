namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardTypes() : IQuery<AwardTypesModel>
{
    public class Handler : QueryHandler<GetAwardTypes, AwardTypesModel>
    {
        private readonly IDomainRepository<Entity.AwardType> _awardTypeRepository;

        public Handler(IDomainRepository<Entity.AwardType> awardTypeRepository)
        {
            _awardTypeRepository = awardTypeRepository;
        }

        protected override async Task<AwardTypesModel> Handle(GetAwardTypes query)
        {
            return new AwardTypesModel(await _awardTypeRepository.GetAll());
        }
    }
}

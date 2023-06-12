namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityType(int Id) : IQuery<Entity.HelmetQualityType>
{
    public class Handler : QueryHandler<GetHelmetQualityType, Entity.HelmetQualityType>
    {
        private readonly IDomainRepository<Entity.HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<Entity.HelmetQualityType> Handle(GetHelmetQualityType query)
            => await _helmetQualityTypeRepository.Get(query.Id);
    }
}

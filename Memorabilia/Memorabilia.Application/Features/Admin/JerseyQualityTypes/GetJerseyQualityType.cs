namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityType(int Id) : IQuery<Entity.JerseyQualityType>
{
    public class Handler : QueryHandler<GetJerseyQualityType, Entity.JerseyQualityType>
    {
        private readonly IDomainRepository<Entity.JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<Entity.JerseyQualityType> Handle(GetJerseyQualityType query)
            => await _jerseyQualityTypeRepository.Get(query.Id);
    }
}

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetHelmetQualityTypes() : IQuery<Entity.HelmetQualityType[]>
{
    public class Handler : QueryHandler<GetHelmetQualityTypes, Entity.HelmetQualityType[]>
    {
        private readonly IDomainRepository<Entity.HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<Entity.HelmetQualityType[]> Handle(GetHelmetQualityTypes query)
            => await _helmetQualityTypeRepository.GetAll();
    }
}

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetJerseyQualityTypes() : IQuery<Entity.JerseyQualityType[]>
{
    public class Handler : QueryHandler<GetJerseyQualityTypes, Entity.JerseyQualityType[]>
    {
        private readonly IDomainRepository<Entity.JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<Entity.JerseyQualityType[]> Handle(GetJerseyQualityTypes query)
            => await _jerseyQualityTypeRepository.GetAll();
    }
}

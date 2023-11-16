namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public record GetJerseyQualityTypes() : IQuery<Entity.JerseyQualityType[]>
{
    public class Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository) 
        : QueryHandler<GetJerseyQualityTypes, Entity.JerseyQualityType[]>
    {
        protected override async Task<Entity.JerseyQualityType[]> Handle(GetJerseyQualityTypes query)
            => await jerseyQualityTypeRepository.GetAll();
    }
}

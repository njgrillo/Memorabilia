namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyTypes() : IQuery<Entity.JerseyType[]>
{
    public class Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository) 
        : QueryHandler<GetJerseyTypes, Entity.JerseyType[]>
    {
        protected override async Task<Entity.JerseyType[]> Handle(GetJerseyTypes query)
            => await jerseyTypeRepository.GetAll();
    }
}

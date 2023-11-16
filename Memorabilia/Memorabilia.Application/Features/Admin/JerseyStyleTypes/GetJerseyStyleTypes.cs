namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleTypes() : IQuery<Entity.JerseyStyleType[]>
{
    public class Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository) 
        : QueryHandler<GetJerseyStyleTypes, Entity.JerseyStyleType[]>
    {
        protected override async Task<Entity.JerseyStyleType[]> Handle(GetJerseyStyleTypes query)
            => await jerseyStyleTypeRepository.GetAll();
    }
}

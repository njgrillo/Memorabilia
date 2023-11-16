namespace Memorabilia.Application.Features.Admin.Orientations;

public record GetOrientations() : IQuery<Entity.Orientation[]>
{
    public class Handler(IDomainRepository<Entity.Orientation> orientationRepository) 
        : QueryHandler<GetOrientations, Entity.Orientation[]>
    {
        protected override async Task<Entity.Orientation[]> Handle(GetOrientations query)
            => await orientationRepository.GetAll();
    }
}

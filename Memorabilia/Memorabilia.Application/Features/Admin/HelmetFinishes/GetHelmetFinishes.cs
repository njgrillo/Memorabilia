namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinishes() : IQuery<Entity.HelmetFinish[]>
{
    public class Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository) 
        : QueryHandler<GetHelmetFinishes, Entity.HelmetFinish[]>
    {
        protected override async Task<Entity.HelmetFinish[]> Handle(GetHelmetFinishes query)
            => await helmetFinishRepository.GetAll();
    }
}

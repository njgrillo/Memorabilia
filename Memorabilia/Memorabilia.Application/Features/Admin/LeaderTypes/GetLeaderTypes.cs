namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderTypes() : IQuery<Entity.LeaderType[]>
{
    public class Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository) 
        : QueryHandler<GetLeaderTypes, Entity.LeaderType[]>
    {
        protected override async Task<Entity.LeaderType[]> Handle(GetLeaderTypes query)
            => await leaderTypeRepository.GetAll();
    }
}

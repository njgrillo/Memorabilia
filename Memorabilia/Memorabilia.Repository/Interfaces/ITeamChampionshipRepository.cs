namespace Memorabilia.Repository.Interfaces;

public interface ITeamChampionshipRepository : IDomainRepository<Entity.Champion>
{
    Task<Entity.Champion[]> GetAll(int? teamId = null);
}

namespace Memorabilia.Repository.Interfaces;

public interface ITeamChampionshipRepository : IDomainRepository<Champion>
{
    Task<Champion[]> GetAll(int? teamId = null);
}

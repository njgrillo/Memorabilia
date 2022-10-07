using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface ITeamDivisionRepository : IDomainRepository<TeamDivision>
{
    Task<IEnumerable<TeamDivision>> GetAll(int? teamId = null);
}

using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IAutographRepository : IDomainRepository<Autograph>
{
    Task<IEnumerable<Autograph>> GetAll(int? memorabiliaId = null, int? userId = null);
}

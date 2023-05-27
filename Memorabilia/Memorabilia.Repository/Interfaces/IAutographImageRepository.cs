using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IAutographImageRepository : IDomainRepository<AutographImage>
{
    Task<List<AutographImage>> GetAll(int autographId);
}

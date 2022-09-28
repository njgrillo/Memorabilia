using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonAwardRepository
    {
        Task<IEnumerable<PersonAward>> GetAll(int awardTypeId);
    }
}

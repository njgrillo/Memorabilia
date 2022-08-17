using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonAwardRepository
    {
        Task<IEnumerable<PersonAward>> GetAll(int awardTypeId);
    }
}

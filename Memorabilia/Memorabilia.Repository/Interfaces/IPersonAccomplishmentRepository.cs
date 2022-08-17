using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonAccomplishmentRepository
    {
        Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId);
    }
}

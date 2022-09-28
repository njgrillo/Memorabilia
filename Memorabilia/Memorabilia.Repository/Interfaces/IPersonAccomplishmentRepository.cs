using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonAccomplishmentRepository
    {
        Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId);
    }
}

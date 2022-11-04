using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IPersonCollegeRepository
{
    Task<IEnumerable<PersonCollege>> GetAll(int? collegeId = null, int? sportLeagueLevelId = null);
}

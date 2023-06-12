namespace Memorabilia.Repository.Interfaces;

public interface IPersonCollegeRepository
{
    Task<IEnumerable<Entity.PersonCollege>> GetAll(int? collegeId = null, 
                                                   int? sportLeagueLevelId = null);
}

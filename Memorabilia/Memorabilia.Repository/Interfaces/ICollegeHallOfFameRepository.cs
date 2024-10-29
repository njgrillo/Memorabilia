namespace Memorabilia.Repository.Interfaces;

public interface ICollegeHallOfFameRepository
{
    Task<CollegeHallOfFame[]> GetAll(int collegeId);
}

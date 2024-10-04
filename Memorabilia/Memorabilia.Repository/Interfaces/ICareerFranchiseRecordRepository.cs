namespace Memorabilia.Repository.Interfaces;

public interface ICareerFranchiseRecordRepository
{
    Task<CareerFranchiseRecord[]> GetAll(int recordTypeId);

    Task<CareerFranchiseRecord[]> GetAllByFranchise(int franchiseId);
}

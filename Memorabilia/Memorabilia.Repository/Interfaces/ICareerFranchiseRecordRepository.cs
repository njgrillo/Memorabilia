namespace Memorabilia.Repository.Interfaces;

public interface ICareerFranchiseRecordRepository
{
    Task<CareerFranchiseRecord[]> GetAll(int recordTypeId);
}

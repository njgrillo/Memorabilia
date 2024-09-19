namespace Memorabilia.Repository.Interfaces;

public interface ISingleSeasonFranchiseRecordRepository
{
    Task<SingleSeasonFranchiseRecord[]> GetAll(int sportId);
}

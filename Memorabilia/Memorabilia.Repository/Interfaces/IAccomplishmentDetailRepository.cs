namespace Memorabilia.Repository.Interfaces;

public interface IAccomplishmentDetailRepository
    : IDomainRepository<AccomplishmentDetail>
{
    Task<AccomplishmentDetail[]> GetAll(int accomplishmentTypeId);
}

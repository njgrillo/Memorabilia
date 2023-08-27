namespace Memorabilia.Repository.Interfaces;

public interface IAccomplishmentDetailRepository
    : IDomainRepository<Entity.AccomplishmentDetail>
{
    Task<Entity.AccomplishmentDetail[]> GetAll(int accomplishmentTypeId);
}

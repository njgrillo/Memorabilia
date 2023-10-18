namespace Memorabilia.Repository.Interfaces;

public interface IPersonAccomplishmentRepository
{
    Task<PersonAccomplishment[]> GetAll();

    Task<IEnumerable<PersonAccomplishment>> GetAll(int accomplishmentTypeId);
}

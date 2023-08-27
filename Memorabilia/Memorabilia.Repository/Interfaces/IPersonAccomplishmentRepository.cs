namespace Memorabilia.Repository.Interfaces;

public interface IPersonAccomplishmentRepository
{
    Task<Entity.PersonAccomplishment[]> GetAll();

    Task<IEnumerable<Entity.PersonAccomplishment>> GetAll(int accomplishmentTypeId);
}

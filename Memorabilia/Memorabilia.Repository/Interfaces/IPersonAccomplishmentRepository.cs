namespace Memorabilia.Repository.Interfaces;

public interface IPersonAccomplishmentRepository
{
    Task<IEnumerable<Entity.PersonAccomplishment>> GetAll(int accomplishmentTypeId);
}

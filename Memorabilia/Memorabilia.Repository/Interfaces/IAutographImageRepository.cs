namespace Memorabilia.Repository.Interfaces;

public interface IAutographImageRepository 
    : IDomainRepository<Entity.AutographImage>
{
    Task<Entity.AutographImage[]> GetAll(int autographId);
}

namespace Memorabilia.Repository.Interfaces;

public interface IAutographImageRepository 
    : IDomainRepository<AutographImage>
{
    Task<AutographImage[]> GetAll(int autographId);
}

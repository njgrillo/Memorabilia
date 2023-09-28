namespace Memorabilia.Repository.Interfaces;

public interface ISignatureIdentificationRepository : IDomainRepository<Entity.SignatureIdentification>
{
    Task<PagedResult<Entity.SignatureIdentification>> GetAll(PageInfo pageInfo);

    Task<Entity.SignatureIdentification> GetRandom();
}

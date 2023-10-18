namespace Memorabilia.Repository.Interfaces;

public interface ISignatureIdentificationRepository : IDomainRepository<SignatureIdentification>
{
    Task<PagedResult<SignatureIdentification>> GetAll(PageInfo pageInfo);

    Task<SignatureIdentification> GetRandom();
}

namespace Memorabilia.Repository.Interfaces;

public interface ISignatureIdentificationRepository : IDomainRepository<SignatureIdentification>
{
    Task<PagedResult<SignatureIdentification>> GetAll(PageInfo pageInfo, int? userId = null);

    Task<SignatureIdentification> GetRandom();
}

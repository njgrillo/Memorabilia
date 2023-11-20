namespace Memorabilia.Repository.Interfaces;

public interface ISignatureIdentificationRepository : IDomainRepository<SignatureIdentification>
{
    Task<PagedResult<SignatureIdentification>> GetAll(PageInfo pageInfo, 
                                                      int userId,
                                                      bool excludeLoggedInUser);

    Task<SignatureIdentification> GetRandom();
}

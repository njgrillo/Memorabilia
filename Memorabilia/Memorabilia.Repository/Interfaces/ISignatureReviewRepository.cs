namespace Memorabilia.Repository.Interfaces;

public interface ISignatureReviewRepository : IDomainRepository<SignatureReview>
{
    Task<PagedResult<SignatureReview>> GetAll(PageInfo pageInfo);

    Task<SignatureReview> GetRandom();
}

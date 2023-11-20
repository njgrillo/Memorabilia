namespace Memorabilia.Repository.Interfaces;

public interface ISignatureReviewRepository : IDomainRepository<SignatureReview>
{
    Task<PagedResult<SignatureReview>> GetAll(PageInfo pageInfo,
                                              int userId,
                                              bool excludeLoggedInUser);

    Task<SignatureReview> GetRandom();
}

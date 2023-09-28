namespace Memorabilia.Repository.Interfaces;

public interface ISignatureReviewRepository : IDomainRepository<Entity.SignatureReview>
{
    Task<PagedResult<Entity.SignatureReview>> GetAll(PageInfo pageInfo);

    Task<Entity.SignatureReview> GetRandom();
}

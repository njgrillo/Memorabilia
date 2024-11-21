namespace Memorabilia.Repository.Interfaces;

public interface IPromoterPaymentOptionRepository : IDomainRepository<PromoterPaymentOption>
{
    Task<PromoterPaymentOption[]> GetAll(int userId);
}

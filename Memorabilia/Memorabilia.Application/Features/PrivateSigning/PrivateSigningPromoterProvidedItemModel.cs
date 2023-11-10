namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPromoterProvidedItemModel
{
    private readonly Entity.PrivateSigningPromoterProvidedItem _privateSigningPromoterProvidedItem;

    public PrivateSigningPromoterProvidedItemModel() { }

    public PrivateSigningPromoterProvidedItemModel(Entity.PrivateSigningPromoterProvidedItem privateSigningPromoterProvidedItem)
    {
        _privateSigningPromoterProvidedItem = privateSigningPromoterProvidedItem;
    }

    public int PrivateSigningId 
        => _privateSigningPromoterProvidedItem.PrivateSigningId;

    public int PromoterProvideItemId
        => _privateSigningPromoterProvidedItem.PromoterProvidedItemId;
}

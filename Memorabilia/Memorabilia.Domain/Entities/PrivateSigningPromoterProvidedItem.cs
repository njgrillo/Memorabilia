﻿namespace Memorabilia.Domain.Entities;

public class PrivateSigningPromoterProvidedItem : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningPromoterProvidedItem() { }

    public PrivateSigningPromoterProvidedItem(int privateSigningId,
                                              int promoterProvidedItemId)
    {
        PrivateSigningId = privateSigningId;
        PromoterProvidedItemId = promoterProvidedItemId;
    }

    public virtual PrivateSigning PrivateSigning { get; private set; }

    public int PrivateSigningId { get; private set; }

    public virtual PromoterProvidedItem PromoterProvidedItem { get; private set; }

    public int PromoterProvidedItemId { get; private set; }
}

﻿namespace Memorabilia.Domain.Entities;

public class MemorabiliaTransactionSale : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaTransactionSale() { }

    public MemorabiliaTransactionSale(int memorabiliaId,
                                      int memorabiliaTransactionId,
                                      decimal saleAmount)
    {
        MemorabiliaId = memorabiliaId;
        MemorabiliaTransactionId = memorabiliaTransactionId;
        SaleAmount = saleAmount;
    }

    public virtual Memorabilia Memorabilia { get; private set; }

    public int MemorabiliaId { get; private set; }

    public virtual MemorabiliaTransaction Transaction { get; private set; }

    public int MemorabiliaTransactionId { get; private set; }

    public decimal SaleAmount { get; private set; }

    public void Set(int memorabiliaId,
                    decimal saleAmount)
    {
        MemorabiliaId = memorabiliaId;
        SaleAmount = saleAmount;
    }
}

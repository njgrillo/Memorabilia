﻿namespace Memorabilia.Domain.Entities;

public class PrivateSigningCustomItemTypeGroup : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningCustomItemTypeGroup() { }

    public PrivateSigningCustomItemTypeGroup(int itemTypeId,
                                             int privateSigningCustomItemGroupId)
    {
        ItemTypeId = itemTypeId;
        PrivateSigningCustomItemGroupId = privateSigningCustomItemGroupId;  
    }

    public int ItemTypeId { get; private set; }

    public virtual PrivateSigningCustomItemGroup PrivateSigningCustomItemGroup { get; private set; }

    public int PrivateSigningCustomItemGroupId { get; private set; }
}

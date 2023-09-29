﻿namespace Memorabilia.Domain.Entities;

public class PrivateSigningCustomItemGroup : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningCustomItemGroup() { }

    public PrivateSigningCustomItemGroup(int createdByUserId,
                                         DateTime createdDate,
                                         string name)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = createdDate;
        Name = name;
    }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public string Name { get; private set; }
}

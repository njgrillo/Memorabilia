﻿namespace Memorabilia.Domain.Entities;

public class MemorabiliaLevelType : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaLevelType() { }

    public MemorabiliaLevelType(int memorabiliaId, int levelTypeId)
    {
        MemorabiliaId = memorabiliaId;
        LevelTypeId = levelTypeId;
    }

    public int LevelTypeId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int levelTypeId)
    {
        LevelTypeId = levelTypeId;
    }
}

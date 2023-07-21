﻿namespace Memorabilia.Domain.Entities;

public class AwardDetail : Framework.Library.Domain.Entity.DomainEntity
{
    public AwardDetail() { }

    public AwardDetail(int awardTypeId)
    {
        AwardTypeId = awardTypeId;
    }

    public AwardDetail(int awardTypeId, 
                       int beginYear, 
                       int? endYear, 
                       int? numberOfWinners, 
                       int? monthAwarded)
    {
        AwardTypeId = awardTypeId;
        BeginYear = beginYear;
        EndYear = endYear;
        NumberOfWinners = numberOfWinners;
        MonthAwarded = monthAwarded;
    }

    public int AwardTypeId { get; private set; }

    public int BeginYear { get; private set; }

    public int? EndYear { get; private set; }

    public virtual List<AwardExclusionYear> ExclusionYears { get; set; }
        = new();

    public int? MonthAwarded { get; private set; }

    public int? NumberOfWinners { get; private set; }

    public void RemoveExclusionYears(int[] ids)
    {
        if (!ids.Any())
            return;

        AwardExclusionYear[] deletedExclusionYears
            = ExclusionYears.Where(exclusionYear => ids.Contains(exclusionYear.Id))
                            .ToArray();

        foreach (AwardExclusionYear exclusionYear in deletedExclusionYears)
        {
            ExclusionYears.Remove(exclusionYear);
        }
    }

    public void SetExclusionYear(int year, string reason)
    {
        var exclusionYear = new AwardExclusionYear(Id, year, reason);

        if (!ExclusionYears.Contains(exclusionYear))
            ExclusionYears.Add(exclusionYear);
    }

    public void Set(int beginYear, int? endYear, int? numberOfWinners, int? monthAwarded)
    {
        BeginYear = beginYear;
        EndYear = endYear;
        NumberOfWinners = numberOfWinners;
        MonthAwarded = monthAwarded;
    }
}

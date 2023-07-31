namespace Memorabilia.Application.Features.Services.Admin.Management.Awards;

public class AwardManagementService
{
    private readonly List<int> _missingYears
        = new();

    private bool _numberOfWinnersDoesntMatch;

    public int[] MissingYears()
        => _missingYears.ToArray();

    public bool NumberOfWinnersDoesntMatch()
        => _numberOfWinnersDoesntMatch;    

    public void Analyze(Entity.AwardDetail awardDetail, Entity.PersonAward[] personAwards)
    {
        if (awardDetail.BeginYear == 0)
            return;

        _numberOfWinnersDoesntMatch = awardDetail.NumberOfWinners.HasValue && personAwards.Length == awardDetail.NumberOfWinners;
        _missingYears.Clear();

        int[] personAwardYears = personAwards.Select(personAward => personAward.Year)
                                             .Distinct()         
                                             .ToArray();

        int endYear = awardDetail.EndYear 
            ?? (awardDetail.MonthAwarded.HasValue 
                ? (awardDetail.MonthAwarded.Value > DateTime.UtcNow.Month
                    ? DateTime.UtcNow.Year - 1 
                    : DateTime.UtcNow.Year) 
                : DateTime.UtcNow.Year);

        int[] exclusionYears = awardDetail.ExclusionYears
                                          .Select(exclusionYear => exclusionYear.Year)
                                          .ToArray()
                               ?? Array.Empty<int>();

        for (int year = awardDetail.BeginYear; year <= endYear; year++)
        {
            if (!personAwardYears.Contains(year) && !exclusionYears.Contains(year)) 
            {
                _missingYears.Add(year);
            }
        }
    }      
}

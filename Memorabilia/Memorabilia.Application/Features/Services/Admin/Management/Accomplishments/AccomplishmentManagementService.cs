namespace Memorabilia.Application.Features.Services.Admin.Management.Accomplishments;

public class AccomplishmentManagementService
{
    private readonly List<int> _missingYears
        = [];

    private bool _numberOfWinnersDoesntMatch;

    public int[] MissingYears()
        => _missingYears.ToArray();

    public bool NumberOfWinnersDoesntMatch()
        => _numberOfWinnersDoesntMatch;

    public void AnalyzeRange(Entity.AccomplishmentDetail accomplishmentDetail, 
        Entity.PersonAccomplishment[] personAccomplishments)
    {
        if (!accomplishmentDetail.BeginYear.HasValue)
            return;

        _numberOfWinnersDoesntMatch = accomplishmentDetail.NumberOfWinners > 0 &&
                                      personAccomplishments.Length == accomplishmentDetail.NumberOfWinners;
        _missingYears.Clear();

        int[] personAccomplishmentYears = personAccomplishments.Select(personAccomplishment => personAccomplishment.Year.Value)                                                               
                                                               .Distinct()
                                                               .ToArray();

        int endYear = accomplishmentDetail.EndYear
            ?? (accomplishmentDetail.MonthAccomplished.HasValue
                ? (accomplishmentDetail.MonthAccomplished.Value > DateTime.UtcNow.Month
                    ? DateTime.UtcNow.Year - 1
                    : DateTime.UtcNow.Year)
                : DateTime.UtcNow.Year);

        for (int year = accomplishmentDetail.BeginYear.Value; year <= endYear; year++)
        {
            if (personAccomplishmentYears.Contains(year))
                continue;

            _missingYears.Add(year);
        }
    }

    public void AnalyzeYear(Entity.AccomplishmentDetail accomplishmentDetail,
        Entity.PersonAccomplishment[] personAccomplishments)
    {
        if (!accomplishmentDetail.Year.HasValue)
            return;

        _numberOfWinnersDoesntMatch = accomplishmentDetail.NumberOfWinners > 0 &&
                                      personAccomplishments.Length == accomplishmentDetail.NumberOfWinners;
    }
}

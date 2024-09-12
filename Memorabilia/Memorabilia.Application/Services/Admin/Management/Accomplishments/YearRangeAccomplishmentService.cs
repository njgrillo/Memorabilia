namespace Memorabilia.Application.Services.Admin.Management.Accomplishments;

public class YearRangeAccomplishmentService
{
    public bool HasMissingYears(
        Entity.AccomplishmentDetail accomplishmentDetail,
        Entity.PersonAccomplishment[] personAccomplishments,
        out int[] missingYears
        )
    {
        missingYears = [];

        if (accomplishmentDetail.NumberOfWinners == 0)
        {            
            return false;
        }

        if (accomplishmentDetail.BeginYear.HasValue)
        {
            int count = (accomplishmentDetail.EndYear ?? DateTime.UtcNow.Year) - accomplishmentDetail.BeginYear.Value;

            if (accomplishmentDetail.MonthAccomplished.HasValue && accomplishmentDetail.MonthAccomplished <= DateTime.UtcNow.Month) 
            {
                count++;
            }

            IEnumerable<int> accomplishmentYears 
                = Enumerable.Range(accomplishmentDetail.BeginYear.Value, count);

            IEnumerable<int> personYears 
                = personAccomplishments.Where(personAccomplishment => personAccomplishment.Year.HasValue)
                                       .Select(personAccomplishment => personAccomplishment.Year.Value)
                                       .Distinct();

            if (accomplishmentYears.Any() && accomplishmentDetail.NumberOfWinners != personAccomplishments.Count())
            {
                missingYears = accomplishmentYears.Except(personYears).OrderBy(x => x).ToArray(); //
            }            
        }
        
        return missingYears.Length != 0;
    }
}

namespace Memorabilia.Application.Services.Admin.Management.Accomplishments;

public class SingleOccurranceAccomplishmentService
{
    public bool HasMissingNumberOfOccurrences(
        Entity.AccomplishmentDetail accomplishmentDetail,
        Entity.PersonAccomplishment[] personAccomplishments,
        out int numberOfMissingOccurrences
        )
    {
        if (accomplishmentDetail.NumberOfWinners == 0)
        {
            numberOfMissingOccurrences = 0;
            return false;
        }

        int numberOfOccurrences = GetNumberOfOccurrences(personAccomplishments);

        bool hasMissingNumberOfOccurences = numberOfOccurrences != accomplishmentDetail.NumberOfWinners;

        numberOfMissingOccurrences = hasMissingNumberOfOccurences
            ? accomplishmentDetail.NumberOfWinners - numberOfOccurrences
            : 0;

        return hasMissingNumberOfOccurences;
    }

    private static int GetNumberOfOccurrences(Entity.PersonAccomplishment[] personAccomplishments)
    {
        if (personAccomplishments.First().AccomplishmentTypeId == Constant.AccomplishmentType.CombinedNoHitter.Id)
        {
            return personAccomplishments.DistinctBy(x => x.Date).Count();
        }

        return personAccomplishments.Length;
    }
}

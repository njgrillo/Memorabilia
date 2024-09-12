namespace Memorabilia.Domain.Entities;

public class AccomplishmentDetail : Entity
{
    public AccomplishmentDetail() { }

    public AccomplishmentDetail(int accomplishmentTypeId)
    {
        AccomplishmentTypeId = accomplishmentTypeId;
    }

    public AccomplishmentDetail(int accomplishmentTypeId,
                                int? beginYear,
                                int? endYear,
                                int? year,
                                int numberOfWinners,
                                int? monthAccomplished,
                                bool ignoreManagement)
    {
        AccomplishmentTypeId = accomplishmentTypeId;
        BeginYear = beginYear;
        EndYear = endYear;
        Year = year;
        NumberOfWinners = numberOfWinners;
        MonthAccomplished = monthAccomplished;
        IgnoreManagement = ignoreManagement;
    }

    public int AccomplishmentTypeId { get; private set; }

    public int? BeginYear { get; private set; }

    public int? EndYear { get; private set; }

    public bool IgnoreManagement { get; private set; }

    public int? MonthAccomplished { get; private set; }

    public int NumberOfWinners { get; private set; }

    public int? Year { get; private set; }

    public void Set(int? beginYear,
                    int? endYear,
                    int? year,
                    int numberOfWinners,
                    int? monthAccomplished,
                    bool ignoreManagement)
    {
        BeginYear = beginYear;
        EndYear = endYear;
        Year = year;
        NumberOfWinners = numberOfWinners;
        MonthAccomplished = monthAccomplished;
        IgnoreManagement = ignoreManagement;
    }
}

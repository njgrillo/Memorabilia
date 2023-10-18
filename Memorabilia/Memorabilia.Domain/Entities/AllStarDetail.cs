namespace Memorabilia.Domain.Entities;

public class AllStarDetail : DomainIdEntity
{
    public AllStarDetail() { }

    public AllStarDetail(int sportLeagueLevelId,
                         int year,
                         int numberOfAllStars,
                         int monthPlayed)
    {
        MonthPlayed = monthPlayed;
        NumberOfAllStars = numberOfAllStars;
        SportLeagueLevelId = sportLeagueLevelId;
        Year = year;
    }

    public int MonthPlayed { get; private set; }

    public int NumberOfAllStars { get; private set; }

    public virtual SportLeagueLevel SportLeagueLevel { get; set; }

    public int SportLeagueLevelId { get; private set; }

    public int Year { get; private set; }    

    public void Set(int numberOfAllStars,
                    int monthPlayed)
    {
        MonthPlayed = monthPlayed;
        NumberOfAllStars = numberOfAllStars;
    }
}

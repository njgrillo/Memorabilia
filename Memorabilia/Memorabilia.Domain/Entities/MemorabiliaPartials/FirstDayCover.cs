namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetFirstDayCover(int[] personIds,
                                 int sizeId,
                                 DateTime? date,
                                 int[] sportIds,
                                 int[] teamIds)
    {
        SetSize(sizeId);
        SetFirstDayCover(date);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    private void SetFirstDayCover(DateTime? date)
    {
        if (FirstDayCover == null)
        {
            FirstDayCover = new MemorabiliaFirstDayCover(Id, date);
            return;
        }

        FirstDayCover.Set(date);
    }
}

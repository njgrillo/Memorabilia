namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetJerseyNumber(int? number, int? personId, int? sportId, int? teamId)
    {
        SetJerseyNumber(number);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    private void SetJerseyNumber(int? number)
    {
        if (number.HasValue)
        {
            if (JerseyNumber == null)
            {
                JerseyNumber = new MemorabiliaJerseyNumber(Id, number.Value);
                return;
            }

            JerseyNumber.Set(number.Value);
        }
        else
        {
            if (JerseyNumber != null)
                JerseyNumber = null;
        }        
    }
}

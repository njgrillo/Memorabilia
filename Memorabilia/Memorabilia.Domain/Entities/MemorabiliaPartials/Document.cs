namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetDocument(int[] personIds,
                            int sizeId,
                            int[] teamIds)
    {
        SetPeople(personIds);
        SetSize(sizeId);
        SetTeams(teamIds);
    }
}

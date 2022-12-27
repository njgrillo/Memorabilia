namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetCompactDisc(int[] personIds)
    {
        SetPeople(personIds);
    }
}

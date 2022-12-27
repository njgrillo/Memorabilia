namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBookplate(int? personId)
    {
        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }
}

namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
{
    public void SetBookplate(int? personId)
    {
        if (!personId.HasValue)
            People = [];
        else
            SetPeople(personId.Value);
    }
}

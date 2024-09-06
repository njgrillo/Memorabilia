namespace Memorabilia.Domain.Entities;

public class DisplayCase : Entity
{
    public DisplayCase() { }

    public DisplayCase(string description, string name, int privacyTypeId, int userId)
    {
        Description = description;
        Name = name;
        PrivacyTypeId = privacyTypeId;
        UserId = userId;
    }

    public string Description { get; private set; }

    public virtual List<DisplayCaseMemorabilia> Memorabilias { get; private set; }
        = [];

    public string Name { get; private set; }

    public int PrivacyTypeId { get; private set; }

    public virtual User User { get; set; }

    public int UserId { get; private set; }

    public void Set(string description, string name, int privacyTypeId)
    {
        Description = description;
        Name = name;
        PrivacyTypeId = privacyTypeId;
    }

    public void SetMemorabilia(int memorabilaId, int xPosition, int yPosition, bool isDeleted)
    {
        DisplayCaseMemorabilia displayCaseMemorabilia 
            = Memorabilias.SingleOrDefault(memorabilia => memorabilia.MemorabiliaId == memorabilaId);

        if (displayCaseMemorabilia is null && !isDeleted)
        {
            Memorabilias.Add(new DisplayCaseMemorabilia(Id, memorabilaId, xPosition, yPosition));
            return;
        }

        if (isDeleted)
        {
            Memorabilias.Remove(displayCaseMemorabilia);
            return;
        }

        displayCaseMemorabilia.Set(xPosition, yPosition);
    }
}

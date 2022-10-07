namespace Memorabilia.Domain.Entities;

public class MemorabiliaBook : Framework.Library.Domain.Entity.DomainEntity
{
    public MemorabiliaBook() { }

    public MemorabiliaBook(int memorabiliaId, string edition, bool hardCover, string publisher, string title)
    {
        MemorabiliaId = memorabiliaId;
        Edition = edition;
        HardCover = hardCover;
        Publisher = publisher;
        Title = title;
    }

    public string Edition { get; private set; }

    public bool HardCover { get; private set; }

    public int MemorabiliaId { get; private set; }

    public string Publisher { get; private set; } 
    
    public string Title { get; private set; }

    public void Set(string edition, bool hardCover, string publisher, string title)
    {
        Edition = edition;
        HardCover = hardCover;
        Publisher = publisher;
        Title = title;
    }
}

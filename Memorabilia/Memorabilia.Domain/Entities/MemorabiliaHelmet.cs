namespace Memorabilia.Domain.Entities;

public class MemorabiliaHelmet : HistoryEntity
{
    public MemorabiliaHelmet() { }

    public MemorabiliaHelmet(int memorabiliaId, 
                             int? helmetFinishId, 
                             int? helmetQualityTypeId, 
                             int? helmetTypeId, 
                             bool throwback)
    {
        MemorabiliaId = memorabiliaId;
        HelmetFinishId = helmetFinishId;
        HelmetQualityTypeId = helmetQualityTypeId;
        HelmetTypeId = helmetTypeId;
        Throwback = throwback;
    }

    public int? HelmetFinishId { get; private set; }

    public int? HelmetQualityTypeId { get; private set; }

    public int? HelmetTypeId { get; private set; }

    public int MemorabiliaId { get; private set; }

    public bool Throwback { get; private set; }

    public void Set(int? helmetFinishId,
                    int? helmetQualityTypeId,
                    int? helmetTypeId,
                    bool throwback)
    {
        HelmetFinishId = helmetFinishId;
        HelmetQualityTypeId = helmetQualityTypeId;
        HelmetTypeId = helmetTypeId;
        Throwback = throwback;
    }
}

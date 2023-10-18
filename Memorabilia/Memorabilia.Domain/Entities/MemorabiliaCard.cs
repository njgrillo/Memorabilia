namespace Memorabilia.Domain.Entities;

public class MemorabiliaCard : Entity
{
    public MemorabiliaCard() { }

    public MemorabiliaCard(int memorabiliaId, 
                           int orientationId, 
                           bool custom, 
                           bool licensed, 
                           int? year)
    {
        MemorabiliaId = memorabiliaId;
        OrientationId = orientationId;
        Custom = custom;
        Licensed = licensed;
        Year = year;
    }

    public bool Custom { get; private set; }

    public bool Licensed { get; private set; }

    public int MemorabiliaId { get; private set; }

    public int OrientationId { get; private set; }

    public int? Year { get; private set; }

    public void Set(int orientationId, 
                    bool custom, 
                    bool licensed, 
                    int? year)
    {
        OrientationId = orientationId;
        Custom = custom;
        Licensed = licensed;
        Year = year;
    }
}

namespace Memorabilia.Domain.Entities;

public class AutographSpot : Entity
{
    public AutographSpot() { }

    public AutographSpot(int autographId, int spotId)
    {
        AutographId = autographId;
        SpotId = spotId;
    }

    public int AutographId { get; private set; }

    public int SpotId { get; private set; }

    public void Set(int spotId)
    {
        SpotId = spotId;
    }
}
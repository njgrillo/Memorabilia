namespace Memorabilia.Domain.Entities;

public class AcquisitionType : DomainEntity
{
    public AcquisitionType() { }

    public AcquisitionType(string name, string abbreviation) : base(name, abbreviation) { }
}

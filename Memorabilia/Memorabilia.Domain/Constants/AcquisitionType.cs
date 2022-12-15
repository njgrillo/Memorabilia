namespace Memorabilia.Domain.Constants;

public sealed class AcquisitionType : DomainItemConstant
{
    public static readonly AcquisitionType PrivateSigning = new(1, "Private Signing");
    public static readonly AcquisitionType PublicSigning = new(2, "Public Signing");
    public static readonly AcquisitionType InPerson = new(3, "In Person", "IP");
    public static readonly AcquisitionType ThroughTheMail = new(4, "Through the Mail", "TTM");
    public static readonly AcquisitionType Trade = new(5, "Trade");
    public static readonly AcquisitionType Purchase = new(6, "Purchase");
    public static readonly AcquisitionType Gift = new(7, "Gift");

    public static readonly AcquisitionType[] All =
    {        
        Gift,
        InPerson,
        PrivateSigning,
        PublicSigning,
        Purchase,
        ThroughTheMail,
        Trade            
    };

    public static readonly AcquisitionType[] MemorabiliaAcquisitionTypes =
    {
        Gift,
        Purchase,
        Trade
    };

    private AcquisitionType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static bool CanHaveCost(AcquisitionType acquisitionType)
    {
        var acquisitionTypes = new List<AcquisitionType>
        {
            InPerson,
            PrivateSigning,
            PublicSigning,
            Purchase,
            ThroughTheMail
        };

        return acquisitionTypes.Contains(acquisitionType);
    }

    public static AcquisitionType Find(int id)
    {
        return All.SingleOrDefault(acquisitionType => acquisitionType.Id == id);
    }    
    
    public static AcquisitionType Find(string name)
    {
        return All.SingleOrDefault(acquisitionType => acquisitionType.Name == name);
    }
}

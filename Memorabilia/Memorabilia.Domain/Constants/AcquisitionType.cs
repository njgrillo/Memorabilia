using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AcquisitionType
    {
        public static readonly AcquisitionType PrivateSigning = new(1, "Private Signing", string.Empty);
        public static readonly AcquisitionType PublicSigning = new(2, "Public Signing", string.Empty);
        public static readonly AcquisitionType InPerson = new(3, "In Person", "IP");
        public static readonly AcquisitionType ThroughTheMail = new(4, "Through the Mail", "TTM");
        public static readonly AcquisitionType Trade = new(5, "Trade", string.Empty);
        public static readonly AcquisitionType Purchase = new(6, "Purchase", string.Empty);

        public static readonly AcquisitionType[] All =
        {
            PrivateSigning,
            PublicSigning,
            InPerson,
            ThroughTheMail,
            Trade,
            Purchase
        };

        private AcquisitionType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AcquisitionType Find(int id)
        {
            return All.SingleOrDefault(AcquisitionType => AcquisitionType.Id == id);
        }
    }
}

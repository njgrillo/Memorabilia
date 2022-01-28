using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class FullSizeHelmetType
    {
        public static readonly FullSizeHelmetType Authentic = new(1, "Authentic", "AUTH");
        public static readonly FullSizeHelmetType Replica = new(2, "Public Signing", "REP");

        public static readonly FullSizeHelmetType[] All =
        {
            Authentic,
            Replica
        };

        private FullSizeHelmetType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static FullSizeHelmetType Find(int id)
        {
            return All.SingleOrDefault(FullSizeHelmetType => FullSizeHelmetType.Id == id);
        }
    }
}

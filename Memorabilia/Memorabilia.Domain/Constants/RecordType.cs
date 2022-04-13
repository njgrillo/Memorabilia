using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class RecordType
    {
        public static readonly RecordType ExtraBaseHits = new(1, "Extra Base Hits", string.Empty);
        public static readonly RecordType RunsBattingIn = new(2, "Runs Batting In", "RBI");
        public static readonly RecordType TotalBases = new(3, "Total Bases", string.Empty);

        public static readonly RecordType[] All =
        {
            ExtraBaseHits,
            RunsBattingIn,
            TotalBases
        };

        private RecordType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static RecordType Find(int id)
        {
            return All.SingleOrDefault(recordType => recordType.Id == id);
        }
    }
}

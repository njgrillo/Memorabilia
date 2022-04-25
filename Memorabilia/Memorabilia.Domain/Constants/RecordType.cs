using Framework.Extension;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class RecordType
    {
        public static readonly RecordType ExtraBaseHits = new(1, "Extra Base Hits", string.Empty);
        public static readonly RecordType FastestPitch = new(11, "Fastest Pitch", string.Empty);
        public static readonly RecordType GrandSlamsByPitcher = new(10, "Grand Slams By Pitcher", string.Empty);
        public static readonly RecordType HomeRuns = new (4, "Home Runs", string.Empty);
        public static readonly RecordType OnBasePercentage = new (6, "On-Base Percentage", string.Empty);
        public static readonly RecordType PostseasonInningsPitched = new (9, "Postseason Innings Pitched", string.Empty);
        public static readonly RecordType RunsBattingIn = new(2, "Runs Batting In", "RBI");
        public static readonly RecordType SluggingPercentage = new (7, "Slugging Percentage", string.Empty);
        public static readonly RecordType TotalBases = new(3, "Total Bases", string.Empty);
        public static readonly RecordType Walks = new(5, "Walks", string.Empty);
        public static readonly RecordType WorldSeriesEarnedRunAverage = new(8, "World Series Earned Run Average", "WS ERA");

        public static readonly RecordType[] All =
        {
            ExtraBaseHits,
            FastestPitch,
            GrandSlamsByPitcher,
            HomeRuns,
            OnBasePercentage,
            PostseasonInningsPitched,
            RunsBattingIn,
            SluggingPercentage,
            TotalBases,
            Walks,
            WorldSeriesEarnedRunAverage
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

        public override string ToString()
        {
            return !Abbreviation.IsNullOrEmpty() ? Abbreviation : Name;
        }
    }
}

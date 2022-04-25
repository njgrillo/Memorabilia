namespace Memorabilia.Domain.Entities
{
    public class BaseballBattingStatistics : Framework.Domain.Entity.DomainEntity
    {
        public BaseballBattingStatistics() { }

        public BaseballBattingStatistics(int personId, 
                                         int year, 
                                         int? atbats,
                                         int? doubles,
                                         int? hits,
                                         int? homeruns,
                                         int? runs,
                                         int? runsBattedIn,
                                         int? singles,
                                         int? strikeouts,
                                         int? triples,
                                         int? walks)
        {
            PersonId = personId;
            Year = year;
            AtBats = atbats;
            Doubles = doubles;
            Hits = hits;
            Homeruns = homeruns;
            Runs = runs;
            RunsBattedIn = runsBattedIn;
            Singles = singles;
            Strikeouts = strikeouts;
            Triples = triples;
            Walks = walks;
        }

        public int? AtBats { get; private set; }

        public int? Doubles { get; private set; }

        public int? Hits { get; private set; }

        public int? Homeruns { get; private set; }

        public virtual Person Person { get; set; }

        public int PersonId { get; private set; }

        public int? Runs { get; private set; }

        public int? RunsBattedIn { get; private set; }

        public int? Singles { get; private set; }

        public int? Strikeouts { get; private set; }

        public int? Triples { get; private set; }

        public int? Walks { get; private set; }

        public int Year { get; private set; }

        public void Set(int year,
                        int? atbats,
                        int? doubles,
                        int? hits,
                        int? homeruns,
                        int? runs,
                        int? runsBattedIn,
                        int? singles,
                        int? strikeouts,
                        int? triples,
                        int? walks)
        {
            Year = year;
            AtBats = atbats;
            Doubles = doubles;
            Hits = hits;
            Homeruns = homeruns;
            Runs = runs;
            RunsBattedIn = runsBattedIn;
            Singles = singles;
            Strikeouts = strikeouts;
            Triples = triples;
            Walks = walks;
        }
    }
}

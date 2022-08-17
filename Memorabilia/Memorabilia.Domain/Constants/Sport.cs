using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Sport
    {
        public static readonly Sport Baseball = new(1, "Baseball", string.Empty);
        public static readonly Sport Basketball = new(2, "Basketball", string.Empty);
        public static readonly Sport Football = new(3, "Football", string.Empty);
        public static readonly Sport Golf = new(6, "Golf", string.Empty);
        public static readonly Sport Hockey = new(4, "Hockey", string.Empty);
        public static readonly Sport Soccer= new(5, "Soccer", "Futbol");
        public static readonly Sport Tennis= new(7, "Tennis", string.Empty);

        public static readonly Sport[] All =
        {
            Baseball,
            Basketball,
            Football,
            Golf,
            Hockey,
            Soccer,
            Tennis
        };

        public static readonly Sport[] AllStarGameSports =
        {
            Baseball,
            Basketball,
            Hockey
        };

        public static readonly Sport[] ProBowlGameSports =
        {
            Football
        };

        private Sport(int id, string name, string alternateName)
        {
            Id = id;
            Name = name;
            AlternateName = alternateName;
        }

        public string AlternateName { get; }

        public int Id { get; }

        public string Name { get; }

        public static Sport Find(int id)
        {
            return All.SingleOrDefault(sport => sport.Id == id);
        }

        public static bool HasAllStarGames(params int[] sportIds)
        {
            return sportIds.Select(id => Find(id)).Any(sport => AllStarGameSports.Contains(sport));
        }

        public static bool HasProBowlGames(params int[] sportIds)
        {
            return sportIds.Select(id => Find(id)).Any(sport => ProBowlGameSports.Contains(sport));
        }
    }
}

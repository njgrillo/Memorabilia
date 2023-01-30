namespace Memorabilia.Domain.Constants;

public sealed class Sport : DomainItemConstant
{
    public static readonly Sport Baseball = new(1, "Baseball");
    public static readonly Sport Basketball = new(2, "Basketball");
    public static readonly Sport Boxing = new(11, "Boxing");
    public static readonly Sport Football = new(3, "Football");
    public static readonly Sport Golf = new(6, "Golf");
    public static readonly Sport Hockey = new(4, "Hockey");
    public static readonly Sport MixedMartialArts = new(12, "Mixed Martial Arts");
    public static readonly Sport Soccer= new(5, "Soccer", "Futbol");
    public static readonly Sport Tennis= new(7, "Tennis");

    public static readonly Sport[] All =
    {
        Baseball,
        Basketball,
        Boxing,
        Football,
        Golf,
        Hockey,
        MixedMartialArts,
        Soccer,
        Tennis
    };

    public static readonly Sport[] AllStarGameSports =
    {
        Baseball,
        Basketball,
        Football,
        Hockey
    };

    public static readonly Sport[] PositionSports =
    {
        Baseball,
        Basketball,
        Football,
        Hockey,
        Soccer
    };

    public static readonly Sport[] ProBowlGameSports =
    {
        Football
    };

    private Sport(int id, string name, string alternateName = null) : base(id, name)
    {
        AlternateName = alternateName;
    }

    public string AlternateName { get; }

    public static Sport Find(int id)
    {
        return All.SingleOrDefault(sport => sport.Id == id);
    }

    public static bool HasAllStarGames(params Sport[] sports)
    {
        return sports.Any(sport => AllStarGameSports.Contains(sport));
    }

    public static bool HasProBowlGames(params Sport[] sports)
    {
        return sports.Any(sport => ProBowlGameSports.Contains(sport));
    }

    public static bool IsPositionSport(params Sport[] sports)
    {
        return sports.Any(sport => PositionSports.Contains(sport));
    }
}

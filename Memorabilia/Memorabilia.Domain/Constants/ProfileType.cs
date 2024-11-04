namespace Memorabilia.Domain.Constants;

public sealed class ProfileType
{
    public static readonly ProfileType Actor = new ("Actor");
    public static readonly ProfileType Actress = new ("Actress");
    public static readonly ProfileType Astronaut = new ("Astronaut");
    public static readonly ProfileType Baseball = new ("Baseball");
    public static readonly ProfileType Basketball = new ("Basketball");
    public static readonly ProfileType Celebrity = new ("Celebrity");
    public static readonly ProfileType Comedian = new ("Comedian");
    public static readonly ProfileType FamousRelative = new ("FamousRelative");
    public static readonly ProfileType Football = new ("Football");
    public static readonly ProfileType Hockey = new ("Hockey");
    public static readonly ProfileType Musician = new ("Musician");
    public static readonly ProfileType Podcaster = new ("Podcaster");
    public static readonly ProfileType Politician = new ("Politician");
    public static readonly ProfileType President = new ("President");
    public static readonly ProfileType Singer = new ("Singer");

    public static readonly ProfileType[] All =
    [
        Actor,
        Actress,
        Astronaut,
        Baseball,
        Basketball,
        Celebrity,
        Comedian,
        FamousRelative,
        Football,
        Hockey,
        Musician,
        Podcaster,
        Politician,
        President,
        Singer
    ];

    private ProfileType(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

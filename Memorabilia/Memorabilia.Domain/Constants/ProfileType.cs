namespace Memorabilia.Domain.Constants;

public sealed class ProfileType
{
    public static readonly ProfileType Baseball = new ("Baseball");

    public static readonly ProfileType[] All =
    {
        Baseball
    };

    private ProfileType(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}

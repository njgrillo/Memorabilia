using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AuthenticType
    {
        public static readonly AuthenticType GameUsed = new(1, "Game Used", string.Empty);
        public static readonly AuthenticType GameIssued = new(2, "Game Issued", string.Empty);
        public static readonly AuthenticType None = new(3, "None", string.Empty);
        public static readonly AuthenticType Other = new(4, "Other", string.Empty);

        public static readonly AuthenticType[] All =
        {
            GameUsed,
            GameIssued,
            None,
            Other
        };

        private AuthenticType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AuthenticType Find(int id)
        {
            return All.SingleOrDefault(authenticType => authenticType.Id == id);
        }
    }
}

namespace Memorabilia.Domain.Constants
{
    public sealed class AuthenticationCompany
    {
        public static readonly AuthenticationCompany Beckett = new(2, "Beckett Authentication Services", "BAS");
        public static readonly AuthenticationCompany Fanatics = new(7, "Fanatics", string.Empty);
        public static readonly AuthenticationCompany JSA = new(1, "James Spence Authentication", "JSA");
        public static readonly AuthenticationCompany Leaf = new(9, "Leaf", string.Empty);
        public static readonly AuthenticationCompany MAB = new(10, "MAB Celebrity Services", "MAB");
        public static readonly AuthenticationCompany MajorLeagueBaseball = new(8, "Major League Baseball", "MLB");
        public static readonly AuthenticationCompany Other = new(12, "Other", string.Empty);
        public static readonly AuthenticationCompany Player = new(4, "Player Hologram", string.Empty);
        public static readonly AuthenticationCompany PSA = new(3, "Professional Sports Authenticator", "PSA");
        public static readonly AuthenticationCompany Radke = new(11, "Radke", string.Empty);
        public static readonly AuthenticationCompany Steiner = new(5, "Steiner", string.Empty);
        public static readonly AuthenticationCompany TriStar = new(6, "TriStar", string.Empty);

        public static readonly AuthenticationCompany[] All =
        {
            Beckett,
            Fanatics,
            JSA,
            Leaf,
            MAB,
            MajorLeagueBaseball,
            Other,
            Player,
            PSA,
            Radke,
            Steiner,
            TriStar
        };

        public static readonly AuthenticationCompany[] BigThree =
        {
            Beckett,
            JSA,
            PSA
        };

        private AuthenticationCompany(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AuthenticationCompany Find(int id)
        {
            return All.SingleOrDefault(authenticationCompany => authenticationCompany.Id == id);
        }
    }
}

using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AuthenticationCompany
    {
        public static readonly AuthenticationCompany JSA = new(1, "James Spence Authentication", "JSA");
        public static readonly AuthenticationCompany BAS = new(2, "Beckett Authentication Services", "BAS");
        public static readonly AuthenticationCompany PSA = new(3, "Professional Sports Authenticator", "PSA");

        public static readonly AuthenticationCompany[] All =
        {
            JSA,
            BAS,
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
            return All.SingleOrDefault(AuthenticationCompany => AuthenticationCompany.Id == id);
        }
    }
}

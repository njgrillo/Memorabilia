using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class PrivacyType
    {
        public static readonly PrivacyType Public = new(1, "Public");
        public static readonly PrivacyType Private = new(2, "Private");

        public static readonly PrivacyType[] All =
        {
            Public,
            Private
        };

        private PrivacyType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static PrivacyType Find(int id)
        {
            return All.SingleOrDefault(privacyType => privacyType.Id == id);
        }
    }
}

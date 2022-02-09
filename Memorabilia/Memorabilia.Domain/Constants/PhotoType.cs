using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class PhotoType
    {
        public static readonly PhotoType Glossy = new(1, "Glossy", string.Empty);
        public static readonly PhotoType Matte = new(2, "Matte", string.Empty);
        public static readonly PhotoType Unknown = new(3, "Unknown", string.Empty);

        public static readonly PhotoType[] All =
        {
            Glossy,
            Matte,
            Unknown
        };

        private PhotoType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static PhotoType Find(int id)
        {
            return All.SingleOrDefault(photoType => photoType.Id == id);
        }
    }
}

using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class ImageType
    {
        public static readonly ImageType Primary = new(1, "All Star");
        public static readonly ImageType Secondary = new(2, "Black Image");

        public static readonly ImageType[] All =
        {
            Primary,
            Secondary
        };

        private ImageType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static ImageType Find(int id)
        {
            return All.SingleOrDefault(imageType => imageType.Id == id);
        }
    }
}

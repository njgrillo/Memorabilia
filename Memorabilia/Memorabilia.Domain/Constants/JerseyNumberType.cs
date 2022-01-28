using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class JerseyNumberType
    {
        public static readonly JerseyNumberType Stitched = new(1, "Stitched", string.Empty);
        public static readonly JerseyNumberType ScreenPrinted = new(2, "Screen Printed", string.Empty);

        public static readonly JerseyNumberType[] All =
        {
            Stitched,
            ScreenPrinted
        };

        private JerseyNumberType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static JerseyNumberType Find(int id)
        {
            return All.SingleOrDefault(JerseyNumberType => JerseyNumberType.Id == id);
        }
    }
}

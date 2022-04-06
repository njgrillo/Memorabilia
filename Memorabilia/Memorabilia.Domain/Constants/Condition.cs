using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Condition
    {
        public static readonly Condition Pristine = new(1, "Pristine", string.Empty);
        public static readonly Condition GemMint = new(2, "Gem Mint", string.Empty);
        public static readonly Condition Mint = new(3, "Mint", string.Empty);
        public static readonly Condition NearMint = new(4, "Near Mint", string.Empty);
        public static readonly Condition Excellent = new(5, "Excellent", string.Empty);
        public static readonly Condition Fair = new(6, "Fair", string.Empty);
        public static readonly Condition Poor = new(7, "Poor", string.Empty);

        public static readonly Condition[] All =
        {
            Pristine,
            GemMint,
            Mint,
            NearMint,
            Excellent,
            Fair,
            Poor             
        };

        private Condition(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static Condition Find(int id)
        {
            return All.SingleOrDefault(condition => condition.Id == id);
        }

        public static Condition Find(string name)
        {
            return All.SingleOrDefault(condition => condition.Name == name);
        }
    }
}

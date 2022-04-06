using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class PersonStep
    {
        public static readonly PersonStep HallOfFame = new(4, "Hall Of Fame");
        public static readonly PersonStep Occupation = new(2, "Occupations");
        public static readonly PersonStep Person = new(1, "Person");
        public static readonly PersonStep Team = new(3, "Teams");

        public static readonly PersonStep[] All =
        {
           HallOfFame,
           Occupation,
           Person,
           Team
        };

        private PersonStep(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static PersonStep Find(int id)
        {
            return All.SingleOrDefault(personStep => personStep.Id == id);
        }
    }
}

using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class TeamStep
    {
        public static readonly TeamStep Championship = new(5, "Championships");
        public static readonly TeamStep Conference = new(3, "Conferences");
        public static readonly TeamStep Division = new(2, "Divisions");       
        public static readonly TeamStep League = new(4, "Leagues");       
        public static readonly TeamStep Team = new(1, "Team");

        public static readonly TeamStep[] All =
        {
           Championship,
           Conference,
           Division,
           League,
           Team
        };

        private TeamStep(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static TeamStep Find(int id)
        {
            return All.SingleOrDefault(teamStep => teamStep.Id == id);
        }
    }
}

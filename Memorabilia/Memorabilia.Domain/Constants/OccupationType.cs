namespace Memorabilia.Domain.Constants
{
    public sealed class OccupationType
    {
        public static readonly OccupationType Primary = new(1, "Primary");
        public static readonly OccupationType Secondary = new(2, "Secondary");

        public static readonly OccupationType[] All =
        {
            Primary,
            Secondary
        };

        private OccupationType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static OccupationType Find(int id)
        {
            return All.SingleOrDefault(occupationType => occupationType.Id == id);
        }
    }
}

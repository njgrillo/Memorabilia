namespace Memorabilia.Domain.Constants
{
    public sealed class EditModeType
    {
        public static readonly EditModeType Add = new(1, "Add");
        public static readonly EditModeType Edit = new(2, "Edit");

        public static readonly EditModeType[] All =
        {
            Add,
            Edit
        };

        private EditModeType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}

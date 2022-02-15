using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class Role
    {
        public static readonly Role SuperAdmin = new(1, "Super Admin");
        public static readonly Role Admin = new(2, "Admin");
        public static readonly Role User = new(3, "User");

        public static readonly Role[] All =
        {            
            Admin,
            SuperAdmin,
            User
        };

        private Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static Role Find(int id)
        {
            return All.SingleOrDefault(role => role.Id == id);
        }
    }
}

namespace Memorabilia.Domain.Constants;

public sealed class Role : DomainItemConstant
{
    public static readonly Role Admin = new(1, "Admin");
    public static readonly Role User = new(2, "User");

    public static readonly Role[] All =
    {            
        Admin,
        User
    };

    private Role(int id, string name) : base(id, name) { }

    public static Role Find(int id)
    {
        return All.SingleOrDefault(role => role.Id == id);
    }
}

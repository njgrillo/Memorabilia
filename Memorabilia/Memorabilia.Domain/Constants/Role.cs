namespace Memorabilia.Domain.Constants;

public sealed class Role : DomainItemConstant
{
    public static readonly Role Admin = new(1, "Admin");
    public static readonly Role Complimentary = new(2, "Complimentary");
    public static readonly Role NonSubscriber = new(3, "Non Subscriber");
    public static readonly Role Promoter = new(4, "Promoter");
    public static readonly Role SubscriberTier1 = new(5, "Subscriber Tier 1");
    public static readonly Role SubscriberTier2 = new(6, "Subscriber Tier 2");
    public static readonly Role TestUser = new(7, "Test User");

    public static readonly Role[] All =
    {            
        Admin,
        Complimentary,
        NonSubscriber,
        Promoter,
        SubscriberTier1,
        SubscriberTier2,
        TestUser
    };

    public static readonly Role[] HighestLevelRoles =
    {
        Admin,
        Complimentary,
        Promoter,
        TestUser
    };

    private Role(int id, string name) 
        : base(id, name) { }

    public static Role Find(int id)
        => All.SingleOrDefault(role => role.Id == id);

    public static Role FindByName(string name)
        => All.SingleOrDefault(role => role.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}

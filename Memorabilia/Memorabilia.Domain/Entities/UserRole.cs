namespace Memorabilia.Domain.Entities;

public class UserRole : Framework.Library.Domain.Entity.DomainEntity
{
    public UserRole() { }

    public UserRole(int roleId,
                    int userId)
    {
        RoleId = roleId;
        UserId = userId;
    }

    public virtual Role Role { get; private set; }

    public int RoleId { get; private set; }

    public virtual User User { get; private set; }

    public int UserId { get; private set; }

    public void SetRole(int roleId)
    { 
        RoleId = roleId; 
    }
}

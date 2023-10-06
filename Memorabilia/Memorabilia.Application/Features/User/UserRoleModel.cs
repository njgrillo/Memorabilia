namespace Memorabilia.Application.Features.User;

public class UserRoleModel
{
	private readonly Entity.UserRole _userRole;

	public UserRoleModel() { }

	public UserRoleModel(Entity.UserRole userRole)
	{
		_userRole = userRole;
	}

	public int Id
		=> _userRole.Id;

	public int RoleId
		=> _userRole.RoleId;

	public int UserId
		=> _userRole.UserId;
}

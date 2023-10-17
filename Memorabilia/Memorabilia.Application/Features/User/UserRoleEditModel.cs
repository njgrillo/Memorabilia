namespace Memorabilia.Application.Features.User;

public class UserRoleEditModel : EditModel
{
	public UserRoleEditModel() { }

	public UserRoleEditModel(Entity.UserRole userRole)
	{
		Id = userRole.Id;
		RoleId = userRole.RoleId;
		UserId = userRole.UserId;
	}

	public int RoleId { get; set; }

	public int UserId { get; set; }
}

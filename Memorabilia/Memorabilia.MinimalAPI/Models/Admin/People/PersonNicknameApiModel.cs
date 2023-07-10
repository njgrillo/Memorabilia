namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonNicknameApiModel
{
    private readonly Entity.PersonNickname _personNickname;

	public PersonNicknameApiModel(Entity.PersonNickname personNickname)
	{
        _personNickname = personNickname;
	}

	public string Nickname
		=> _personNickname.Nickname;
}

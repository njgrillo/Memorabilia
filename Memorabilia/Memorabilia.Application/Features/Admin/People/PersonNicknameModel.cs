namespace Memorabilia.Application.Features.Admin.People;

public class PersonNicknameModel
{
    private readonly Entity.PersonNickname _personNickname;

    public PersonNicknameModel() { }

    public PersonNicknameModel(Entity.PersonNickname personNickname)
    {
        _personNickname = personNickname;
    }

    public int Id 
        => _personNickname.Id;

    public string Nickname 
        => _personNickname.Nickname;

    public int PersonId 
        => _personNickname.PersonId;
}

using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class PersonNicknameViewModel
{
    private readonly PersonNickname _personNickname;

    public PersonNicknameViewModel() { }

    public PersonNicknameViewModel(PersonNickname personNickname)
    {
        _personNickname = personNickname;
    }

    public int Id => _personNickname.Id;

    public string Nickname => _personNickname.Nickname;

    public int PersonId => _personNickname.PersonId;
}

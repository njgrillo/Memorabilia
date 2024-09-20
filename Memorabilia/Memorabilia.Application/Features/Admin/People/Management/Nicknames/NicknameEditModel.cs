namespace Memorabilia.Application.Features.Admin.People.Management.Nicknames;

public class NicknameEditModel : EditModel
{
    public NicknameEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public NicknameEditModel(Entity.PersonNickname personNickname)
    {
        Id = personNickname.Id;
        Nickname = personNickname.Nickname;
        PersonId = personNickname.PersonId;
    }

    public string Nickname { get; set; }

    public int PersonId { get; set; }

    public Guid? TemporaryId { get; set; }

    public void Set(string nickname)
    {
        Nickname = nickname;
    }

    public void Set(int id, string nickname)
    {
        Id = id;
        Nickname = nickname;
    }
}

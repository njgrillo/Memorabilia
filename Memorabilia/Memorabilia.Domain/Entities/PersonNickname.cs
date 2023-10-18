namespace Memorabilia.Domain.Entities;

public class PersonNickname : DomainIdEntity
{
    public PersonNickname() { }

    public PersonNickname(int personId, string nickname)
    {
        PersonId = personId;
        Nickname = nickname;
    }

    public string Nickname { get; private set; }

    public int PersonId { get; private set; }

    public void Set(string nickname)
    {
        Nickname = nickname;
    }
}

namespace Memorabilia.Domain.Entities
{
    public class PersonNickname : Framework.Domain.Entity.DomainEntity
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
}

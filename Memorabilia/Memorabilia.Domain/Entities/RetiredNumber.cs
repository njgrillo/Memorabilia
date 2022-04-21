namespace Memorabilia.Domain.Entities
{
    public class RetiredNumber : Framework.Domain.Entity.DomainEntity
    {
        public RetiredNumber() { }

        public RetiredNumber(int personId, int franchiseId, int playerNumber)
        {
            PersonId = personId;
            FranchiseId = franchiseId;
            PlayerNumber = playerNumber;
        }

        public int FranchiseId { get; private set; }

        public int PersonId { get; private set; }

        public int PlayerNumber { get; private set; }

        public void Set(int franchiseId, int playerNumber)
        {
            FranchiseId = franchiseId;
            PlayerNumber = playerNumber;
        }
    }
}

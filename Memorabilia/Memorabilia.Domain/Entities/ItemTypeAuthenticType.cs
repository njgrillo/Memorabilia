namespace Memorabilia.Domain.Entities
{
    public class ItemTypeAuthenticType : Framework.Domain.Entity.DomainEntity
    {
        public ItemTypeAuthenticType() { }

        public ItemTypeAuthenticType(int itemTypeId, int authenticTypeId)
        {
            ItemTypeId = itemTypeId;
            AuthenticTypeId = authenticTypeId;
        }

        public int AuthenticTypeId { get; private set; }

        public int ItemTypeId { get; private set; }

        public void Set(int authenticTypeId)
        {
            AuthenticTypeId = authenticTypeId;
        }
    }
}



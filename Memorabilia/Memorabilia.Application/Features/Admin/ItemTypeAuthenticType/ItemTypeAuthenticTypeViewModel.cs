namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class ItemTypeAuthenticTypeViewModel
    {
        private readonly Domain.Entities.ItemTypeAuthenticType _itemTypeAuthenticType;

        public ItemTypeAuthenticTypeViewModel() { }

        public ItemTypeAuthenticTypeViewModel(Domain.Entities.ItemTypeAuthenticType itemTypeAuthenticType)
        {
            _itemTypeAuthenticType = itemTypeAuthenticType;
        }

        public int AuthenticTypeId => _itemTypeAuthenticType.AuthenticTypeId;

        public string AuthenticTypeName => Domain.Constants.AuthenticType.Find(AuthenticTypeId).Name;

        public int Id => _itemTypeAuthenticType.Id;

        public int ItemTypeId => _itemTypeAuthenticType.ItemTypeId;

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId).Name;
    }
}

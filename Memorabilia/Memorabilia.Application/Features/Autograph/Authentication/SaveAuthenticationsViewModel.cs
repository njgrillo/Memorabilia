using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class SaveAuthenticationsViewModel : ViewModel
    {
        public SaveAuthenticationsViewModel() { }

        public SaveAuthenticationsViewModel(IEnumerable<Domain.Entities.AutographAuthentication> authentications)
        {
            Authentications = authentications.Select(authentication => new SaveAuthenticationViewModel(new AuthenticationViewModel(authentication))).ToList();
        }

        public List<SaveAuthenticationViewModel> Authentications { get; set; } = new();

        public int AutographId { get; set; }

        public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

        public string ImagePath => "images/beckett.jpg";

        public ItemType ItemType { get; set; }

        public string ItemTypeName => ItemType.Find(ItemType.Id)?.Name;

        public override string PageTitle => "Authentications";
    }
}

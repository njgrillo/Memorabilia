using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class SaveAuthenticationsViewModel : SaveViewModel
    {
        public SaveAuthenticationsViewModel() { }

        public SaveAuthenticationsViewModel(IEnumerable<Domain.Entities.AutographAuthentication> authentications, 
                                            ItemType itemType, 
                                            int memorabiliaId,
                                            int autographId)
        {
            Authentications = authentications.Select(authentication => new SaveAuthenticationViewModel(new AuthenticationViewModel(authentication))).ToList();
            ItemType = itemType;
            MemorabiliaId = memorabiliaId;
            AutographId = autographId;
        }

        public List<SaveAuthenticationViewModel> Authentications { get; set; } = new();

        public int AutographId { get; set; }

        public AutographStep AutographStep => AutographStep.Authentication;

        public override string BackNavigationPath => $"Autographs/Inscriptions/Edit/{AutographId}";

        public bool CanHaveSpot => ItemType.CanHaveSpot(ItemType);

        public override string ContinueNavigationPath => CanHaveSpot
                ? $"Autographs/Spot/Edit/{AutographId}"
                : $"Autographs/Image/Edit/{AutographId}";

        public override EditModeType EditModeType => Authentications.Any() ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public string ImagePath => "images/authenticationcompanies.jpg";

        public ItemType ItemType { get; }

        public string ItemTypeName => ItemType.Find(ItemType.Id)?.Name;

        public int MemorabiliaId { get; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Add ? "Add" : "Edit")} Authentication(s)";
    }
}

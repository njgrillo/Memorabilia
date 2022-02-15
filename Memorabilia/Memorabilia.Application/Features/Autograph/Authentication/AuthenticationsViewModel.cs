using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class AuthenticationsViewModel : ViewModel
    {
        public AuthenticationsViewModel() { }

        public AuthenticationsViewModel(IEnumerable<Domain.Entities.AutographAuthentication> authentications)
        {
            Authentications = authentications.Select(authentication => new AuthenticationViewModel(authentication)).ToList();
        }

        public int AutographId { get; set; }

        public string ImagePath { get; set; }

        public List<AuthenticationViewModel> Authentications { get; set; } = new();

        public override string PageTitle => "Authentications";
    }
}

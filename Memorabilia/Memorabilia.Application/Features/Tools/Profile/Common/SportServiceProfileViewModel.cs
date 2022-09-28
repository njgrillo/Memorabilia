using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class SportServiceProfileViewModel
    {
        private readonly SportService _sportService;

        public SportServiceProfileViewModel(SportService sportService)
        {
            _sportService = sportService;
        }

        public DateTime? DebutDate => _sportService?.DebutDate;

        public DateTime? FreeAgentSigningDate => _sportService?.FreeAgentSigningDate;

        public DateTime? LastAppearanceDate => _sportService?.LastAppearanceDate;
    }
}

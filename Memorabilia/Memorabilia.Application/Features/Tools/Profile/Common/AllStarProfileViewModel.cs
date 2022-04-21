using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class AllStarProfileViewModel
    {
        private readonly AllStar _allStar;

        public AllStarProfileViewModel(AllStar allStar)
        {
            _allStar = allStar;
        }

        public int Year => _allStar.Year;
    }
}

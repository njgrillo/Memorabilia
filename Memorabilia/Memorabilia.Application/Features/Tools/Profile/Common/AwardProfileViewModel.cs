using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class AwardProfileViewModel
    {
        private readonly PersonAward _award;

        public AwardProfileViewModel(PersonAward award)
        {
            _award = award;
        }

        public string AwardTypeAbbreviatedName => Domain.Constants.AwardType.Find(AwardTypeId)?.ToString();

        public int AwardTypeId => _award.AwardTypeId;        

        public int Year => _award.Year;
    }
}

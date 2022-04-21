using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class LeaderProfileViewModel
    {
        private readonly Leader _leader;

        public LeaderProfileViewModel(Leader leader)
        {
            _leader = leader;
        }

        public string LeaderTypeAbbreviatedName => Domain.Constants.LeaderType.Find(LeaderTypeId)?.ToString();

        public int LeaderTypeId => _leader.LeaderTypeId;        

        public int Year => _leader.Year;
    }
}

using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class ChampionshipProfileViewModel
    {
        private readonly Champion _champion;

        public ChampionshipProfileViewModel(Champion champion)
        {
            _champion = champion;
        }

        public int ChampionshipTypeId => _champion.ChampionTypeId;

        public string ChampionshipTypeName => Domain.Constants.ChampionType.Find(ChampionshipTypeId)?.Name;

        public int TeamId => _champion.TeamId;

        public string TeamName => $"{_champion.Team?.Location} {_champion.Team?.Name}";        

        public int Year => _champion.Year;
    }
}

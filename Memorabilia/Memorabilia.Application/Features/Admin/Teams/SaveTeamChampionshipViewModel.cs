namespace Memorabilia.Application.Features.Admin.Teams
{
    public class SaveTeamChampionshipViewModel : SaveViewModel
    {
        public SaveTeamChampionshipViewModel() { }

        public SaveTeamChampionshipViewModel(TeamChampionshipViewModel teamChampionship)
        {
            Id = teamChampionship.Id;
            ChampionshipTypeId = teamChampionship.ChampionTypeId;
            TeamId = teamChampionship.TeamId;
            Year = teamChampionship.Year;
        }        

        public int ChampionshipTypeId { get; set; }

        public string ChampionshipTypeName => Domain.Constants.ChampionType.Find(ChampionshipTypeId)?.Name;

        public Domain.Constants.ChampionType[] ChampionshipTypes => Domain.Constants.ChampionType.All;

        public int TeamId { get; set; }

        public int Year { get; set; }
    }
}

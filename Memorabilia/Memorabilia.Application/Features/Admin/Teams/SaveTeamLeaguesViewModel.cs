﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Teams;

public class SaveTeamLeaguesViewModel : EditModel
{
    public SaveTeamLeaguesViewModel() { }

    public SaveTeamLeaguesViewModel(int teamId)
    {
        TeamId = teamId;
    }

    public SaveTeamLeaguesViewModel(int teamId, List<SaveTeamLeagueViewModel> leagues)
    {
        TeamId = teamId;
        Leagues = leagues;
    }

    public override string BackNavigationPath => $"{AdminDomainItem.Teams.Item}/{AdminDomainItem.Divisions.Item}/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public bool CanHaveConference => SportLeagueLevel != Constant.SportLeagueLevel.MajorLeagueBaseball;

    public override string ContinueNavigationPath => $"{AdminDomainItem.Teams.Item}/Championship/{EditModeType.Update.Name}/{TeamId}/{SportLeagueLevel?.Id}";

    public override EditModeType EditModeType => Leagues.Any() ? EditModeType.Update : EditModeType.Add;

    public string ImageFileName => AdminDomainItem.Leagues.ImageFileName;

    public List<SaveTeamLeagueViewModel> Leagues { get; set; } = new();

    public Constant.SportLeagueLevel SportLeagueLevel { get; set; }

    public int TeamId { get; set; }

    public TeamStep TeamStep => TeamStep.League;
}

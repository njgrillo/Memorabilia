using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Team : Framework.Domain.Entity.DomainEntity
    {
        public Team() { }

        public Team(int franchiseId, string name, string location, string nickname, string abbreviation, int? beginYear, int? endYear, string imagePath)
        {
            FranchiseId = franchiseId;
            Name = name;
            Location = location;
            Nickname = nickname;
            Abbreviation = abbreviation;
            BeginYear = beginYear;
            EndYear = endYear;
            ImagePath = imagePath;
        }

        public string Abbreviation { get; private set; }

        public int? BeginYear { get; private set; }

        public List<TeamConference> Conferences { get; private set; } = new();

        public List<TeamDivision> Divisions { get; private set; } = new();

        public int? EndYear { get; private set; }

        public Franchise Franchise { get; private set; }

        public int FranchiseId { get; private set; }

        public string ImagePath { get; private set; }

        public List<TeamLeague> Leagues { get; private set; } = new();

        public string Location { get; private set; }

        public string Name { get; private set; }

        public string Nickname { get; private set; }

        public void RemoveConferences(int[] teamConferenceIds)
        {
            Conferences.RemoveAll(teamConference => teamConferenceIds.Contains(teamConference.Id));
        }

        public void RemoveDivisions(int[] teamDivisionIds)
        {
            Divisions.RemoveAll(teamDivision => teamDivisionIds.Contains(teamDivision.Id));
        }

        public void RemoveLeagues(int[] teamLeagueIds)
        {
            Leagues.RemoveAll(teamLeague => teamLeagueIds.Contains(teamLeague.Id));
        }

        public void Set(string name, string location, string nickname, string abbreviation, int? beginYear, int? endYear, string imagePath)
        {
            Name = name;
            Location = location;
            Nickname = nickname;
            Abbreviation = abbreviation;
            BeginYear = beginYear;
            EndYear = endYear;
            ImagePath = imagePath;
        }

        public void SetConference(int teamConferenceId, int conferenceId, int? beginYear, int? endYear)
        {
            var conference =  teamConferenceId > 0 ? Conferences.SingleOrDefault(conference => conference.Id == teamConferenceId) : null;

            if (conference == null)
            {
                Conferences.Add(new TeamConference(conferenceId, Id, beginYear, endYear));
                return;
            }

            conference.Set(conferenceId, Id, beginYear, endYear);
        }

        public void SetDivision(int teamDivisionId, int divisionId, int? beginYear, int? endYear)
        {
            var division = teamDivisionId > 0 ? Divisions.SingleOrDefault(division => division.Id == teamDivisionId) : null;

            if (division == null)
            {
                Divisions.Add(new TeamDivision(divisionId, Id, beginYear, endYear));
                return;
            }

            division.Set(divisionId, Id, beginYear, endYear);
        }

        public void SetLeague(int teamLeagueId, int leagueId, int? beginYear, int? endYear)
        {
            var league = teamLeagueId > 0 ? Leagues.SingleOrDefault(league => league.Id == teamLeagueId) : null;

            if (league == null)
            {
                Leagues.Add(new TeamLeague(leagueId, Id, beginYear, endYear));
                return;
            }

            league.Set(leagueId, Id, beginYear, endYear);
        }
    }
}

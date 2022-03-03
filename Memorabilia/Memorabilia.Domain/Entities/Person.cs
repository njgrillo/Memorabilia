using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Person : Framework.Domain.Entity.DomainEntity
    {
        public Person() { }

        public Person(string firstName, 
                      string lastName, 
                      string middleName,
                      string suffix,
                      string nickname,
                      string legalName,
                      string displayName,                       
                      DateTime? birthDate, 
                      DateTime? deathDate, 
                      string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Suffix = suffix;
            Nickname = nickname;
            LegalName = legalName;
            DisplayName = displayName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            ImagePath = imagePath;
            CreateDate = DateTime.UtcNow;
        }

        public DateTime? BirthDate { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? DeathDate { get; private set; }

        public string DisplayName { get; private set; }

        public string FirstName { get; private set; }

        public virtual List<HallOfFame> HallOfFames { get; private set; } = new();

        public string ImagePath { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public string LastName { get; private set; }

        public string LegalName { get; private set; }

        public string MiddleName { get; private set; }

        public string Nickname { get; private set; }

        public virtual List<PersonOccupation> Occupations { get; private set; } = new();

        public virtual List<PersonTeam> Teams { get; private set; } = new();

        public string Suffix { get; private set; }

        public void RemoveHallOfFames(params int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return;

            HallOfFames.RemoveAll(hof => ids.Contains(hof.Id));
        }

        public void RemoveOccupations(params int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return;

            Occupations.RemoveAll(occupation => ids.Contains(occupation.Id));
        }

        public void RemoveTeams(params int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return;

            Teams.RemoveAll(team => ids.Contains(team.Id));
        }

        public void Set(string firstName, 
                        string lastName, 
                        string middleName,
                        string suffix,
                        string nickname,
                        string legalName,
                        string displayName,                         
                        DateTime? birthDate, 
                        DateTime? deathDate, 
                        string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Suffix = suffix;
            Nickname = nickname;
            LegalName = legalName;
            DisplayName = displayName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            ImagePath = imagePath;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetHallOfFame(int sportLeagueLevelId, int? franchiseId, int? inductionYear, decimal? votePercentage)
        {
            var hallOfFame = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevelId == sportLeagueLevelId);

            if (hallOfFame == null)
            {
                HallOfFames.Add(new HallOfFame(inductionYear, Id, sportLeagueLevelId, franchiseId, votePercentage));
                return;
            }

            hallOfFame.Set(inductionYear, sportLeagueLevelId, franchiseId, votePercentage);
        }

        public void SetOccupation(int occupationId, int occupationTypeId)
        {
            var occupation = occupationId > 0 ? Occupations.SingleOrDefault(occupation => occupation.OccupationId == occupationId) : null;

            if (occupation == null)
            {
                Occupations.Add(new PersonOccupation(occupationId, occupationTypeId, Id));
                return;
            }

            occupation.Set(occupationId, occupationTypeId);
        }

        public void SetTeam(int teamId, int? beginYear, int? endYear)
        {
            var team = Teams.SingleOrDefault(team => team.TeamId == teamId && team.BeginYear == beginYear);

            if (team == null)
            {
                Teams.Add(new PersonTeam(Id, teamId, beginYear, endYear));
                return;
            }

            team.Set(teamId, beginYear, endYear);
        }
    }
}

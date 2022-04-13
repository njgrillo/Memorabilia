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
                      string profileName,
                      DateTime? birthDate, 
                      DateTime? deathDate,
                      string[] nicknames)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Suffix = suffix;
            Nickname = nickname;
            LegalName = legalName;
            DisplayName = displayName;
            ProfileName = profileName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            CreateDate = DateTime.UtcNow;

            if (nicknames.Any())
                Nicknames = nicknames.Select(nickname => new PersonNickname(Id, nickname)).ToList();
        }

        public virtual List<AllStar> AllStars { get; private set; } = new();

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

        public virtual List<PersonNickname> Nicknames { get; private set; } = new();

        public virtual List<PersonOccupation> Occupations { get; private set; } = new();

        public string ProfileName { get; private set; }

        public virtual SportService Service { get; private set; }

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
                        string profileName,
                        DateTime? birthDate, 
                        DateTime? deathDate,
                        string[] nicknames)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Suffix = suffix;
            Nickname = nickname;
            LegalName = legalName;
            DisplayName = displayName;
            ProfileName = profileName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            LastModifiedDate = DateTime.UtcNow;

            SetNicknames(nicknames);
        }

        public void SetHallOfFame(int sportLeagueLevelId, int? inductionYear, decimal? votePercentage)
        {
            var hallOfFame = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevelId == sportLeagueLevelId);

            if (hallOfFame == null)
            {
                HallOfFames.Add(new HallOfFame(inductionYear, Id, sportLeagueLevelId, votePercentage));
                return;
            }

            hallOfFame.Set(inductionYear, sportLeagueLevelId, votePercentage);
        }

        public void SetImage(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void SetNicknames(string[] nicknames)
        {
            if (!nicknames.Any())
            {
                Nicknames = new();
                return;
            }

            var existingNicknames = Nicknames.Select(personNickname => personNickname.Nickname);

            foreach (var nickname in nicknames.Where(nickname => !existingNicknames.Contains(nickname)))
            {
                Nicknames.Add(new PersonNickname(Id, nickname));
            }
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

        public void SetService(DateTime? debutDate, DateTime? freeAgentSigningDate, DateTime? lastAppearanceDate)
        {
            if (Service == null)
            {
                Service = new SportService(Id, debutDate, freeAgentSigningDate, lastAppearanceDate);
                return;
            }

            Service.Set(debutDate, freeAgentSigningDate, lastAppearanceDate);
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

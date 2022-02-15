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
                      string suffix, 
                      string fullName, 
                      string nickname, 
                      DateTime? birthDate, 
                      DateTime? deathDate, 
                      string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            Suffix = suffix;
            FullName = fullName;
            Nickname = nickname;
            BirthDate = birthDate;
            DeathDate = deathDate;
            ImagePath = imagePath;
            CreateDate = DateTime.UtcNow;
        }

        public DateTime? BirthDate { get; private set; }

        public DateTime CreateDate { get; private set; }

        public DateTime? DeathDate { get; private set; }

        public string FirstName { get; private set; }

        public string FullName { get; private set; }

        public List<HallOfFame> HallOfFames { get; private set; } = new();

        public string ImagePath { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public string LastName { get; private set; }

        public string Nickname { get; private set; }

        public List<PersonOccupation> Occupations { get; private set; } = new();

        public List<PersonTeam> Teams { get; private set; } = new();

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
                        string suffix, 
                        string fullName, 
                        string nickname, 
                        DateTime? birthDate, 
                        DateTime? deathDate, 
                        string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            Suffix = suffix;
            FullName = fullName;
            Nickname = nickname;
            BirthDate = birthDate;
            DeathDate = deathDate;
            ImagePath = imagePath;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void SetHallOfFame(int sportId, int levelTypeId, int? franchiseId, int? inductionYear, int? voteCount)
        {
            var hallOfFame = HallOfFames.SingleOrDefault(hof => hof.SportId == sportId && hof.LevelTypeId == levelTypeId);

            if (hallOfFame == null)
            {
                HallOfFames.Add(new HallOfFame(inductionYear, Id, sportId, levelTypeId, franchiseId, voteCount));
                return;
            }

            hallOfFame.Set(inductionYear, sportId, levelTypeId, franchiseId, voteCount);
        }

        public void SetOccupation(int occupationId, int occupationTypeId)
        {
            var occupation = Occupations.SingleOrDefault(occupation => occupation.OccupationId == occupationId);

            if (occupation == null)
            {
                Occupations.Add(new PersonOccupation(occupationId, occupationTypeId, Id));
                return;
            }

            occupation.Set(occupationId, occupationTypeId);
        }

        public void SetTeam(int personTeamId, int teamId, int? beginYear, int? endYear)
        {
            var team = Teams.SingleOrDefault(team => team.Id == personTeamId);

            if (team == null)
            {
                Teams.Add(new PersonTeam(Id, teamId, beginYear, endYear));
                return;
            }

            team.Set(teamId, beginYear, endYear);
        }
    }
}

using System;

namespace Memorabilia.Domain.Entities
{
    public class Person : Framework.Domain.Entity.DomainEntity
    {
        public Person() { }

        public Person(string firstName, string lastName, string suffix, string fullName, string nickname, DateTime? birthDate, DateTime? deathDate, string imagePath)
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

        public string ImagePath { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public string LastName { get; private set; }

        public string Nickname { get; private set; }

        public string Suffix { get; private set; }

        public void Set(string firstName, string lastName, string suffix, string fullName, string nickname, DateTime? birthDate, DateTime? deathDate, string imagePath)
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
    }
}

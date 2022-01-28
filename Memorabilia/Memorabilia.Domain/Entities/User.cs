using System;

namespace Memorabilia.Domain.Entities
{
    public class User : Framework.Domain.Entity.DomainEntity
    {
        public User() { }

        public User(string username, string password, string emailAddress, string firstName, string lastName, string phone)
        {
            Username = username;
            Password = password;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            CreateDate = DateTime.UtcNow;

            //Delete this later:
            RoleId = 1;
        }

        public DateTime CreateDate { get; private set; }

        public string EmailAddress { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Password { get; private set; }

        public string Phone { get; private set; }

        public int RoleId { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public string Username { get; private set; }        

        public void SetUser(string password, string emailAddress, string firstName, string lastName, string phone)
        {
            Password = password;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            UpdateDate = DateTime.UtcNow;
        }
    }
}

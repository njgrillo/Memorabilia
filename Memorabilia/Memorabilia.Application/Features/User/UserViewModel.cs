namespace Memorabilia.Application.Features.User
{
    public class UserViewModel
    {
        private readonly Domain.Entities.User _user;

        public UserViewModel() { }

        public UserViewModel(Domain.Entities.User user)
        {
            _user = user;
        }

        public DateTime CreateDate => _user.CreateDate;

        public string EmailAddress => _user.EmailAddress;

        public string FirstName => _user.FirstName;

        public int Id => _user.Id;

        public bool IsValid => _user != null;

        public string LastName => _user.LastName;

        public string Password => _user.Password;

        public string Phone => _user.Phone;

        public DateTime? UpdateDate => _user.UpdateDate;

        public string Username => _user.Username;
    }
}

namespace Memorabilia.Application.Features.User;

public class UserModel : Model
{
    private readonly Entity.User _user;

    public UserModel() { }

    public UserModel(Entity.User user)
    {
        _user = user;
    }

    public DateTime CreateDate 
        => _user.CreateDate;

    public string EmailAddress 
        => _user.EmailAddress;

    public string FirstName 
        => _user.FirstName;

    public int Id 
        => _user.Id;

    public bool IsValid 
        => _user != null;

    public string LastName 
        => _user.LastName;

    public DateTime? UpdateDate 
        => _user.UpdateDate;

    public string Username
        => _user.Username;
}

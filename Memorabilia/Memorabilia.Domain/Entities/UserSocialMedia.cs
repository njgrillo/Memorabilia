namespace Memorabilia.Domain.Entities;

public class UserSocialMedia : DomainIdEntity
{
    public UserSocialMedia() { }

    public UserSocialMedia(int userId,
                           int socialMediaTypeId,
                           string handle)
    {
        Handle = handle;
        SocialMediaTypeId = socialMediaTypeId;
        UserId = userId;
    }

    public string Handle { get; private set; }

    public int SocialMediaTypeId { get; private set; }

    public int UserId { get; private set; }

    public void Set(string handle)
    {
        Handle = handle;
    }
}

namespace Memorabilia.Application.Features.User.Settings;

public class UserSocialMediaEditModel : EditModel
{
    public UserSocialMediaEditModel() { }

    public UserSocialMediaEditModel(Entity.UserSocialMedia userSocialMedia)
    {
        Handle = userSocialMedia.Handle;
        Id = userSocialMedia.Id;        
        SocialMediaType = Constant.SocialMediaType.Find(userSocialMedia.SocialMediaTypeId);
    }

    public string Handle { get; set; }

    public Constant.SocialMediaType SocialMediaType { get; set; }

    public string SocialMediaTypeName
        => SocialMediaType?.Name;
}

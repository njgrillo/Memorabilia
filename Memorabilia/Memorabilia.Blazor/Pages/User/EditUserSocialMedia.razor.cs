namespace Memorabilia.Blazor.Pages.User;

public partial class EditUserSocialMedia
{
    [Parameter]
    public List<UserSocialMediaEditModel> SocialMedias { get; set; }
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected UserSocialMediaEditModel EditModel
        = new();

    private void Add()
    {
        if (EditModel.SocialMediaType == null)
            return;

        SocialMedias.Add(EditModel);

        EditModel = new();
    }

    private void Edit(UserSocialMediaEditModel socialMedia)
    {
        EditModel.Handle = socialMedia.Handle;
        EditModel.SocialMediaType = socialMedia.SocialMediaType;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        UserSocialMediaEditModel socialMedia
            = EditModel.Id > 0
                ? SocialMedias.Single(media => media.Id == EditModel.Id)
                : SocialMedias.Single(media => media.SocialMediaType.Id == EditModel.SocialMediaType.Id);

        socialMedia.Handle = EditModel.Handle;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}

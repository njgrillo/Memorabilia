namespace Memorabilia.Application.Features.User.Settings;

public class UserSettingsEditModel
{
	public UserSettingsEditModel() { }

	public UserSettingsEditModel(Entity.User user)
	{
		GoogleEmailAddress = user.UserSettings?.GoogleEmailAddress ?? string.Empty;
        MicrosoftEmailAddress = user.UserSettings?.MicrosoftEmailAddress ?? string.Empty;
		UseDarkTheme = user.UserSettings?.UseDarkTheme ?? false;
		XHandle = user.UserSettings?.XHandle ?? string.Empty;

		PaymentOptions = user.PaymentOptions
							 .Select(paymentOption => new UserPaymentOptionEditModel(paymentOption))
							 .ToList();

		SocialMedias = user.SocialMedias
						   .Select(socialMedia => new UserSocialMediaEditModel(socialMedia))
                           .ToList();
    }

	public string GoogleEmailAddress { get; set; }

	public string MicrosoftEmailAddress { get; set; }

	public List<UserPaymentOptionEditModel> PaymentOptions { get; set; }
		= new();

    public List<UserSocialMediaEditModel> SocialMedias { get; set; }
        = new();

    public bool UseDarkTheme { get; set; }

	public string XHandle { get; set; }
}

using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.User.Settings;

public class SaveUserSettings
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserPaymentOptionRepository userPaymentOptionRepository,
                         IUserRepository userRepository,
                         IUserSocialMediaRepository userSocialMediaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.User user = await userRepository.Get(applicationStateService.CurrentUser.Id);

            user.SetUserSettings(command.UseDarkTheme,
                                 command.GoogleEmailAddress,
                                 command.MicrosoftEmailAddress,
                                 command.XHandle);

            user.SetShippingAddress(command.ShippingAddress.AddressLine1,
                                    command.ShippingAddress.AddressLine2,
                                    command.ShippingAddress.City,
                                    command.ShippingAddress.Country,
                                    command.ShippingAddress.PostalCode,
                                    command.ShippingAddress.SingleLine,
                                    command.ShippingAddress.StateProvidence);

            await SavePaymentOptions(command, user);
            await SaveSocialMedias(command, user);            

            await userRepository.Update(user);
        }

        private async Task SavePaymentOptions(Command command, Entity.User user)
        {
            if (command.DeletedPaymentOptionIds.Length != 0)
            {
                foreach (int userPaymentOptionId in command.DeletedPaymentOptionIds)
                {
                    Entity.UserPaymentOption userPaymentOption
                        = await userPaymentOptionRepository.Get(userPaymentOptionId);

                    if (userPaymentOption == null)
                        continue;

                    await userPaymentOptionRepository.Delete(userPaymentOption);
                }
            }

            foreach (UserPaymentOptionEditModel paymentOption in command.PaymentOptions)
            {
                user.SetPaymentOption(paymentOption.Id,
                                      paymentOption.PaymentOption.Id,
                                      paymentOption.PaymentHandle,
                                      paymentOption.PaymentOptionType);
            }
        }

        private async Task SaveSocialMedias(Command command, Entity.User user)
        {
            if (command.DeletedSocialMediaIds.Length != 0)
            {
                foreach (int userSocialMediaId in command.DeletedSocialMediaIds)
                {
                    Entity.UserSocialMedia userSocialMedia
                        = await userSocialMediaRepository.Get(userSocialMediaId);

                    if (userSocialMedia == null)
                        continue;

                    await userSocialMediaRepository.Delete(userSocialMedia);
                }
            }

            foreach (UserSocialMediaEditModel socialMedia in command.SocialMedias)
            {
                user.SetSocialMedias(socialMedia.Id,
                                     socialMedia.SocialMediaType.Id,
                                     socialMedia.Handle);
            }
        }
    }

    public class Command(UserSettingsEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int[] DeletedPaymentOptionIds
            => editModel.PaymentOptions
                        .Where(paymentOption => paymentOption.IsDeleted)
                        .Select(paymentOption => paymentOption.Id)
                        .ToArray();

        public int[] DeletedSocialMediaIds
            => editModel.SocialMedias
                        .Where(socialMedia => socialMedia.IsDeleted)
                        .Select(socialMedia => socialMedia.Id)
                        .ToArray();

        public string GoogleEmailAddress
            => editModel.GoogleEmailAddress;

        public string MicrosoftEmailAddress
            => editModel.MicrosoftEmailAddress;

        public UserPaymentOptionEditModel[] PaymentOptions
            => editModel.PaymentOptions
                        .Where(paymentOption => !paymentOption.IsDeleted)
                        .ToArray();

        public AddressEditModel ShippingAddress
            => editModel.ShippingAddress;

        public UserSocialMediaEditModel[] SocialMedias
            => editModel.SocialMedias
                        .Where(socialMedia => !socialMedia.IsDeleted)
                        .ToArray();

        public bool UseDarkTheme
            => editModel.UseDarkTheme;

        public string XHandle
            => editModel.XHandle;
    }
}

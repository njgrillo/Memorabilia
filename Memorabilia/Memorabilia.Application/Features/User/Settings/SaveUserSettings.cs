namespace Memorabilia.Application.Features.User.Settings;

public class SaveUserSettings
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserPaymentOptionRepository _userPaymentOptionRepository;       
        private readonly IUserRepository _userRepository;
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IUserPaymentOptionRepository userPaymentOptionRepository,                       
                       IUserRepository userRepository,
                       IUserSocialMediaRepository userSocialMediaRepository)
        {
            _applicationStateService = applicationStateService;
            _userPaymentOptionRepository = userPaymentOptionRepository;            
            _userRepository = userRepository;
            _userSocialMediaRepository = userSocialMediaRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.User user = await _userRepository.Get(_applicationStateService.CurrentUser.Id);

            user.SetUserSettings(command.UseDarkTheme,
                                 command.GoogleEmailAddress,
                                 command.MicrosoftEmailAddress,
                                 command.XHandle);

            await SavePaymentOptions(command, user);
            await SaveSocialMedias(command, user);            

            await _userRepository.Update(user);
        }

        private async Task SavePaymentOptions(Command command, Entity.User user)
        {
            if (command.DeletedPaymentOptionIds.Any())
            {
                foreach (int userPaymentOptionId in command.DeletedPaymentOptionIds)
                {
                    Entity.UserPaymentOption userPaymentOption
                        = await _userPaymentOptionRepository.Get(userPaymentOptionId);

                    if (userPaymentOption == null)
                        continue;

                    await _userPaymentOptionRepository.Delete(userPaymentOption);
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
            if (command.DeletedSocialMediaIds.Any())
            {
                foreach (int userSocialMediaId in command.DeletedSocialMediaIds)
                {
                    Entity.UserSocialMedia userSocialMedia
                        = await _userSocialMediaRepository.Get(userSocialMediaId);

                    if (userSocialMedia == null)
                        continue;

                    await _userSocialMediaRepository.Delete(userSocialMedia);
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

    public class Command : DomainCommand, ICommand
    {
        private readonly UserSettingsEditModel _editModel;

        public Command(UserSettingsEditModel editModel)
        {
            _editModel = editModel;
        }

        public int[] DeletedPaymentOptionIds
            => _editModel.PaymentOptions
                         .Where(paymentOption => paymentOption.IsDeleted)
                         .Select(paymentOption => paymentOption.Id)
                         .ToArray();

        public int[] DeletedSocialMediaIds
            => _editModel.SocialMedias
                         .Where(socialMedia => socialMedia.IsDeleted)
                         .Select(socialMedia => socialMedia.Id)
                         .ToArray();

        public string GoogleEmailAddress
            => _editModel.GoogleEmailAddress;

        public string MicrosoftEmailAddress
            => _editModel.MicrosoftEmailAddress;

        public UserPaymentOptionEditModel[] PaymentOptions
            => _editModel.PaymentOptions
                         .Where(paymentOption => !paymentOption.IsDeleted)
                         .ToArray();

        public UserSocialMediaEditModel[] SocialMedias
            => _editModel.SocialMedias
                         .Where(socialMedia => !socialMedia.IsDeleted)
                         .ToArray();

        public bool UseDarkTheme
            => _editModel.UseDarkTheme;

        public string XHandle
            => _editModel.XHandle;
    }
}

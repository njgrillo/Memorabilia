namespace Memorabilia.Application.Features.User.Settings;

public record SaveHomeBackgroundImage(string ImageFileName)
    : ICommand
{
    public class Handler(IApplicationStateService applicationStateService, IUserRepository userRepository)
        : CommandHandler<SaveHomeBackgroundImage>
    {
        protected override async Task Handle(SaveHomeBackgroundImage request)
        {
            Entity.User user = await userRepository.Get(applicationStateService.CurrentUser.Id);

            if (user is null)
            {
                return;
            }

            if (request.ImageFileName.IsNullOrEmpty())
            {
                user.RemoveHomeBackgroundImageFileName();
            }
            else
            {
                user.SetHomeBackgroundImageFileName(request.ImageFileName);
            }

            await userRepository.Update(user);
        }
    }
}

namespace Memorabilia.Application.Features.PrivateSigning.Promoter.PaymentOptions;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public class SavePromoterPaymentOptions
{
    public class Handler(IUserRepository userRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.User user = await userRepository.Get(command.UserId);

            foreach (PromoterPaymentOptionEditModel paymentOption in command.PaymentOptions)
            {
                user.SetPromoterPaymentOption(
                    paymentOption.Id, 
                    paymentOption.PrivateSigningPaymentMethodId,
                    paymentOption.PaymentMethodHandle
                    );
            }

            await userRepository.Update(user);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PromoterPaymentOptionsEditModel _editModel;

        public Command(PromoterPaymentOptionsEditModel editModel)
        {
            _editModel = editModel;
        }

        public PromoterPaymentOptionEditModel[] PaymentOptions
            => _editModel.PaymentOptions.Count > 0
                ? _editModel.PaymentOptions.ToArray()
                : [];

        public int UserId
            => _editModel.UserId;
    }
}

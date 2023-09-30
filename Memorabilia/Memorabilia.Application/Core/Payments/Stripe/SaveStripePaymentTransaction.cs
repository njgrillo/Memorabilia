namespace Memorabilia.Application.Core.Payments.Stripe;

public class SaveStripePaymentTransaction
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IStripePaymentTransactionRepository _stripePaymentTransactionRepository;

        public Handler(IStripePaymentTransactionRepository stripePaymentTransactionRepository)
        {
            _stripePaymentTransactionRepository = stripePaymentTransactionRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.StripePaymentTransaction stripePaymentTransaction;

            if (command.IsNew)
            {
                stripePaymentTransaction = new(command.OrderId,
                                               command.PurchaseUserId,
                                               command.TransactionDate,
                                               command.StripePaymentStatusTypeId);

                await _stripePaymentTransactionRepository.Add(stripePaymentTransaction);

                return;
            }

            stripePaymentTransaction = await _stripePaymentTransactionRepository.Get(command.Id);

            stripePaymentTransaction.SetStatus(command.StripePaymentStatusTypeId);

            await _stripePaymentTransactionRepository.Update(stripePaymentTransaction);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly StripePaymentTransactionEditModel _stripePaymentTransactionEditModel;

        public Command(StripePaymentTransactionEditModel stripePaymentTransactionEditModel)
        {
            _stripePaymentTransactionEditModel = stripePaymentTransactionEditModel;
        }

        public int Id
            => _stripePaymentTransactionEditModel.Id;

        public bool IsNew
            => _stripePaymentTransactionEditModel.IsNew;

        public string OrderId
            => _stripePaymentTransactionEditModel.OrderId;

        public int PurchaseUserId
            => _stripePaymentTransactionEditModel.PurchaseUserId;

        public int StripePaymentStatusTypeId
            => _stripePaymentTransactionEditModel.StripePaymentStatusType.Id;

        public DateTime TransactionDate
            => DateTime.UtcNow;        
    }
}

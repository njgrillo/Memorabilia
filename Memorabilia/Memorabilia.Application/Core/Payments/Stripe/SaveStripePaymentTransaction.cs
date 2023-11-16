namespace Memorabilia.Application.Core.Payments.Stripe;

public class SaveStripePaymentTransaction
{
    public class Handler(IStripePaymentTransactionRepository stripePaymentTransactionRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.StripePaymentTransaction stripePaymentTransaction;

            if (command.IsNew)
            {
                stripePaymentTransaction = new(command.OrderId,
                                               command.PurchaseUserId,
                                               command.TransactionDate,
                                               command.StripePaymentStatusTypeId);

                await stripePaymentTransactionRepository.Add(stripePaymentTransaction);

                return;
            }

            stripePaymentTransaction = await stripePaymentTransactionRepository.Get(command.Id);

            stripePaymentTransaction.SetStatus(command.StripePaymentStatusTypeId);

            await stripePaymentTransactionRepository.Update(stripePaymentTransaction);
        }
    }

    public class Command(StripePaymentTransactionEditModel stripePaymentTransactionEditModel) 
        : DomainCommand, ICommand
    {
        public int Id
            => stripePaymentTransactionEditModel.Id;

        public bool IsNew
            => stripePaymentTransactionEditModel.IsNew;

        public string OrderId
            => stripePaymentTransactionEditModel.OrderId;

        public int PurchaseUserId
            => stripePaymentTransactionEditModel.PurchaseUserId;

        public int StripePaymentStatusTypeId
            => stripePaymentTransactionEditModel.StripePaymentStatusType.Id;

        public DateTime TransactionDate
            => DateTime.UtcNow;        
    }
}

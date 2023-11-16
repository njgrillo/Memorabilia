namespace Memorabilia.Application.Features.SignatureReview;

[AuthorizeByPermission(Enum.Permission.EditSignatureAuthentication)]
public class SaveSignatureReviewUserResult
{
    public class Handler(ISignatureReviewRepository signatureReviewRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.SignatureReview signatureReview
                = await signatureReviewRepository.Get(command.SignatureReviewId);

            Entity.SignatureReviewUserResult signatureReviewUserResult
                = signatureReview.UserResults.SingleOrDefault(result => result.CreatedUserId == command.CreatedUserId);

            if (signatureReviewUserResult == null)
            {
                signatureReview.AddUserResult(command.CreatedDate,
                                              command.CreatedUserId,
                                              command.Note,
                                              command.SignatureReviewResultTypeId);
            }
            else
            {
                signatureReview.SetUserResult(signatureReviewUserResult.Id,
                                              command.Note,
                                              command.SignatureReviewResultTypeId);
            }

            await signatureReviewRepository.Update(signatureReview);
        }
    }

    public class Command(SignatureReviewUserResultEditModel signatureReviewUserResultEditModel) 
        : DomainCommand, ICommand
    {
        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => signatureReviewUserResultEditModel.CreatedUserId;

        public string Note
            => signatureReviewUserResultEditModel.Note;

        public int SignatureReviewId
            => signatureReviewUserResultEditModel.SignatureReviewId;

        public int SignatureReviewResultTypeId
            => signatureReviewUserResultEditModel.SignatureReviewResultTypeId;
    }
}

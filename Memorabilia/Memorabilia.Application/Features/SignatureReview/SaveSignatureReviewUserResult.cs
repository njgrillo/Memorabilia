namespace Memorabilia.Application.Features.SignatureReview;

[AuthorizeByPermission(Enum.Permission.SignatureAuthentication)]
public class SaveSignatureReviewUserResult
{
    public class Handler : CommandHandler<Command>
    {
        private readonly ISignatureReviewRepository _signatureReviewRepository;

        public Handler(ISignatureReviewRepository signatureReviewRepository)
        {
            _signatureReviewRepository = signatureReviewRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.SignatureReview signatureReview
                = await _signatureReviewRepository.Get(command.SignatureReviewId);

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

            await _signatureReviewRepository.Update(signatureReview);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SignatureReviewUserResultEditModel _signatureReviewUserResultEditModel;

        public Command(SignatureReviewUserResultEditModel signatureReviewUserResultEditModel)
        {
            _signatureReviewUserResultEditModel = signatureReviewUserResultEditModel;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => _signatureReviewUserResultEditModel.CreatedUserId;

        public string Note
            => _signatureReviewUserResultEditModel.Note;

        public int SignatureReviewId
            => _signatureReviewUserResultEditModel.SignatureReviewId;

        public int SignatureReviewResultTypeId
            => _signatureReviewUserResultEditModel.SignatureReviewResultTypeId;
    }
}

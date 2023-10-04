namespace Memorabilia.Application.Features.SignatureReview;

[AuthorizeByPermission(Enum.Permission.EditSignatureAuthentication)]
public class SaveSignatureReview
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
                = new(command.CreatedDate,
                      command.CreatedUserId,
                      command.Note,
                      command.PersonId);

            foreach (SignatureReviewImageEditModel image in command.Images)
            {
                signatureReview.AddImage(image.FileName);
            }

            await _signatureReviewRepository.Add(signatureReview);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SignatureReviewEditModel _signatureReviewEditModel;

        public Command(SignatureReviewEditModel signatureReviewEditModel)
        {
            _signatureReviewEditModel = signatureReviewEditModel;
        }

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => _signatureReviewEditModel.CreatedUserId;

        public SignatureReviewImageEditModel[] Images
            => _signatureReviewEditModel.Images.ToArray();

        public string Note
            => _signatureReviewEditModel.Note;

        public int PersonId
            => _signatureReviewEditModel.Person.Id;
    }
}

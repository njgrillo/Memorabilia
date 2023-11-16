namespace Memorabilia.Application.Features.SignatureReview;

[AuthorizeByPermission(Enum.Permission.EditSignatureAuthentication)]
public class SaveSignatureReview
{
    public class Handler(ISignatureReviewRepository signatureReviewRepository) 
        : CommandHandler<Command>
    {
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

            await signatureReviewRepository.Add(signatureReview);
        }
    }

    public class Command(SignatureReviewEditModel signatureReviewEditModel) 
        : DomainCommand, ICommand
    {
        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedUserId
            => signatureReviewEditModel.CreatedUserId;

        public SignatureReviewImageEditModel[] Images
            => signatureReviewEditModel.Images.ToArray();

        public string Note
            => signatureReviewEditModel.Note;

        public int PersonId
            => signatureReviewEditModel.Person.Id;
    }
}

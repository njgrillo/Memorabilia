namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewEditModel : EditModel
{
    public SignatureReviewEditModel() { }

    public SignatureReviewEditModel(Entity.SignatureReview signatureReview)
    {
        CreatedDate = signatureReview.CreatedDate;
        CreatedUserId = signatureReview.CreatedUserId;
        Id = signatureReview.Id;
        Note = signatureReview.Note;
        Person = new(new PersonModel(signatureReview.Person));
        PersonId = signatureReview.PersonId;

        Images = signatureReview.Images
                                .Select(image => new SignatureReviewImageEditModel(image))
                                .ToList();

        UserResults = signatureReview.UserResults
                                     .Select(result => new SignatureReviewUserResultEditModel(result))
                                     .ToList();
    }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

    public List<SignatureReviewImageEditModel> Images { get; set; }
        = [];

    public string Note { get; set; }

    public PersonEditModel Person { get; set; }

    public int PersonId { get; set; }

    public List<SignatureReviewUserResultEditModel> UserResults { get; set; }
        = [];
}

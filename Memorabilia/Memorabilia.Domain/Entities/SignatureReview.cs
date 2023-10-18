namespace Memorabilia.Domain.Entities;

public class SignatureReview : Entity
{
    public SignatureReview() { }

    public SignatureReview(DateTime createdDate,
                           int createdUserId,
                           string note,
                           int personId)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
        PersonId = personId;
    }

    public SignatureReview(SignatureReview signatureReview)
    {
        CreatedDate = signatureReview.CreatedDate;
        CreatedUser = signatureReview.CreatedUser;
        CreatedUserId = signatureReview.CreatedUserId;
        Id = signatureReview.Id;
        Images = signatureReview.Images;
        Note = signatureReview.Note;
        Person = signatureReview.Person;
        PersonId = signatureReview.PersonId;
        UserResults = signatureReview.UserResults;
    }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public virtual List<SignatureReviewImage> Images { get; private set; }

    public string Note { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public virtual List<SignatureReviewUserResult> UserResults { get; private set; }

    public void AddImage(string fileName)
    {
        Images ??= new();

        Images.Add(new SignatureReviewImage(fileName, Id));
    }

    public void AddUserResult(DateTime createdDate,
                              int createdUserId,
                              string note,
                              int signatureReviewResultTypeId)
    {
        UserResults ??= new();

        UserResults.Add(new SignatureReviewUserResult(createdDate,
                                                      createdUserId,
                                                      note,
                                                      Id,
                                                      signatureReviewResultTypeId));
    }

    public void SetUserResult(int id, 
                              string note,
                              int signatureReviewResultTypeId)
    {
        SignatureReviewUserResult userResultToEdit
            = UserResults.Single(result => result.Id == id);

        userResultToEdit.Set(note, signatureReviewResultTypeId);
    }
}

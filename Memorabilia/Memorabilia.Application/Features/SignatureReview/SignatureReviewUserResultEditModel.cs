namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewUserResultEditModel : EditModel
{
    public SignatureReviewUserResultEditModel() { }

    public SignatureReviewUserResultEditModel(int createdUserId,
                                              int signatureReviewId)
    {
        CreatedUserId = createdUserId;
        SignatureReviewId = signatureReviewId;
    }

    public SignatureReviewUserResultEditModel(int createdUserId,
                                              int id,  
                                              string note,  
                                              int signatureReviewId,
                                              int signatureReviewResultTypeId)
    {
        CreatedUserId = createdUserId;
        Id = id;
        Note = note;
        SignatureReviewId = signatureReviewId;
        SignatureReviewResultTypeId = signatureReviewResultTypeId;
    }

    public SignatureReviewUserResultEditModel(Entity.SignatureReviewUserResult signatureReviewUserResult)
    {
        CreateDate = signatureReviewUserResult.CreatedDate;
        CreatedUserId = signatureReviewUserResult.CreatedUserId;
        Id = signatureReviewUserResult.Id;
        Note = signatureReviewUserResult.Note;
        SignatureReviewId = signatureReviewUserResult.SignatureReviewId;
        SignatureReviewResultTypeId = signatureReviewUserResult.SignatureReviewResultTypeId;
    }

    public DateTime CreateDate { get; set; }

    public int CreatedUserId { get; set; }

    public string Note { get; set; }

    public int SignatureReviewId { get; set; }

    public int SignatureReviewResultTypeId { get; set; }
}

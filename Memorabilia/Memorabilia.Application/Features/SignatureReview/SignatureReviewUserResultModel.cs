namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewUserResultModel
{
    private readonly Entity.SignatureReviewUserResult _signatureReviewUserResult;

    public SignatureReviewUserResultModel() { }

    public SignatureReviewUserResultModel(Entity.SignatureReviewUserResult signatureReviewUserResult)
    {
        _signatureReviewUserResult = signatureReviewUserResult;
    }

    public DateTime CreatedDate
        => _signatureReviewUserResult.CreatedDate;

    public UserModel CreatedUser
        => new(_signatureReviewUserResult.CreatedUser);

    public int CreatedUserId
        => _signatureReviewUserResult.CreatedUserId;

    public int Id
        => _signatureReviewUserResult.Id;   

    public string Note
        => _signatureReviewUserResult.Note;

    public int SignatureReviewId
        => _signatureReviewUserResult.SignatureReviewId;

    public int SignatureReviewResultTypeId
        => _signatureReviewUserResult.SignatureReviewResultTypeId;

    public string SignatureReviewResultTypeName
        => Constant.SignatureReviewResultType.Find(SignatureReviewResultTypeId)?.Name; 
}

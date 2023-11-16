namespace Memorabilia.Application.Features.SignatureReview;

public class SignatureReviewModel
{
    private readonly Entity.SignatureReview _signatureReview;

    public SignatureReviewModel() { }

    public SignatureReviewModel(Entity.SignatureReview signatureReview)
    {
        _signatureReview = signatureReview;

        Images = _signatureReview.Images
                                 .Select(image => new SignatureReviewImageModel(image))
                                 .ToArray();

        UserResults = _signatureReview.UserResults
                                      .Select(result => new SignatureReviewUserResultModel(result))
                                      .ToArray();
    }

    public Constant.SignatureReviewResultType ConsensusResult
        => UserResults.HasAny()
            ? Constant.SignatureReviewResultType.Find(ConsensusSignatureReviewResultTypeId)
            : null;

    public int ConsensusSignatureReviewResultTypeId
        => UserResults.HasAny()
            ? UserResults.GroupBy(x => x.SignatureReviewResultTypeId)
                         .OrderByDescending(x => x.Count())
                         .First()
                         .Key
            : 0;

    public DateTime CreatedDate
        => _signatureReview.CreatedDate;

    public UserModel CreatedUser
        => new(_signatureReview.CreatedUser);

    public bool DisplayDetails { get; set; }

    public int Id
        => _signatureReview.Id;

    public SignatureReviewImageModel[] Images { get; set; }
        = [];

    public string Note
        => _signatureReview.Note;    

    public PersonModel Person
        => _signatureReview != null        
            ? new(_signatureReview.Person)
            : new();

    public int PersonId
        => _signatureReview.PersonId;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;

    public SignatureReviewUserResultModel[] UserResults { get; set; }
        = [];
}

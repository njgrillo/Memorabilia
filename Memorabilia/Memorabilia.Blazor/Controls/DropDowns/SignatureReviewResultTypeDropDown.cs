namespace Memorabilia.Blazor.Controls.DropDowns;

public class SignatureReviewResultTypeDropDown : DropDown<SignatureReviewResultType, int>
{
    protected override void OnInitialized()
    {
        Items = SignatureReviewResultType.All;
        Label = "Result";
    }
}

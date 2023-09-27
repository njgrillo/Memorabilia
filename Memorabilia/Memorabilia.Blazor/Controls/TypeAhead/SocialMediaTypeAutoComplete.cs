namespace Memorabilia.Blazor.Controls.TypeAhead;

public class SocialMediaTypeAutoComplete : DomainEntityAutoComplete<SocialMediaType>
{
    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Social Media Type";
        Placeholder = "Search by social media type...";
        Items = SocialMediaType.All;
    }
}

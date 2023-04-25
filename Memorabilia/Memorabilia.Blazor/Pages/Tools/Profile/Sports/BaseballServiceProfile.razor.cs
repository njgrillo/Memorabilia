using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class BaseballServiceProfile
{
    [Parameter]
    public Person Person { get; set; }

    private string Text;

    protected override void OnParametersSet()
    {
        var text = string.Empty;

        if (Person.Service.FreeAgentSigningDate.HasValue)
            text = $"Free Agent Signing {Person.Service.FreeAgentSigningDate.Value.ToString("MM/dd/yyyy")}";

        if (Person.Service.DebutDate.HasValue)
            text += $"{(!text.IsNullOrEmpty() ? " | " : string.Empty)} Debut  {Person.Service.DebutDate.Value.ToString("MM/dd/yyyy")}";

        if (Person.Service.LastAppearanceDate.HasValue)
            text += $"{(!text.IsNullOrEmpty() ? " | " : string.Empty)} Last Appearance  {Person.Service.LastAppearanceDate.Value.ToString("MM/dd/yyyy")}";

        Text = text;
    }
}

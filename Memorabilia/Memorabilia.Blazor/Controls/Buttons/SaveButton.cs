namespace Memorabilia.Blazor.Controls.Buttons;

public class SaveButton : CustomButton
{
    protected override void OnInitialized()
    {
        Color = Color.Primary;
        StartIcon = Icons.Material.Filled.Save;
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (Text.IsNullOrEmpty())
            Text = "Save";
    }
}

namespace Memorabilia.Blazor.Controls.Buttons;

public class CancelButton : CustomButton
{
    protected override void OnInitialized()
    {
        ButtonType = ButtonType.Button;
        Color = Color.Secondary;
        Text = "Cancel";
    }
}

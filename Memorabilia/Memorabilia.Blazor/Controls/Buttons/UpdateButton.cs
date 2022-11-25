namespace Memorabilia.Blazor.Controls.Buttons;

public class UpdateButton : CustomButton
{
    protected override void OnInitialized()
    {
        ButtonType = ButtonType.Button;
        Color = Color.Secondary;
        Text = "Update";
    }
}

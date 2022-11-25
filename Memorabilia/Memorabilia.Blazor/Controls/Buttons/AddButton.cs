namespace Memorabilia.Blazor.Controls.Buttons;

public class AddButton : CustomButton
{
    protected override void OnInitialized()
    {
        ButtonType = ButtonType.Button;
        Color = Color.Success;
        Text = "Add";
    }
}

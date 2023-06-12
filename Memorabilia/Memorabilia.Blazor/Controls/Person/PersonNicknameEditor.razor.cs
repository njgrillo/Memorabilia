

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonNicknameEditor : ComponentBase
{
    [Parameter]
    public List<PersonNicknameEditModel> Nicknames { get; set; } = new();

    private PersonNicknameEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.Nickname.IsNullOrEmpty())
            return;

        Nicknames.Add(_viewModel);

        _viewModel = new PersonNicknameEditModel();
    }
}

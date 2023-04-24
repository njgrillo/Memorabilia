

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonNicknameEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonNicknameViewModel> Nicknames { get; set; } = new();

    private SavePersonNicknameViewModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.Nickname.IsNullOrEmpty())
            return;

        Nicknames.Add(_viewModel);

        _viewModel = new SavePersonNicknameViewModel();
    }
}

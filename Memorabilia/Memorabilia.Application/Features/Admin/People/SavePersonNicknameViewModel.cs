namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonNicknameViewModel : EditModel
{
    public SavePersonNicknameViewModel() { }

    public SavePersonNicknameViewModel(PersonNicknameViewModel viewModel)
    {
        Id = viewModel.Id;
        Nickname = viewModel.Nickname;
        PersonId = viewModel.PersonId;
    }

    public string Nickname { get; set; }

    public int PersonId { get; set; }
}

namespace Memorabilia.Application.Features.Admin.People;

public class PersonNicknameEditModel : EditModel
{
    public PersonNicknameEditModel() { }

    public PersonNicknameEditModel(PersonNicknameModel viewModel)
    {
        Id = viewModel.Id;
        Nickname = viewModel.Nickname;
        PersonId = viewModel.PersonId;
    }

    public string Nickname { get; set; }

    public int PersonId { get; set; }
}

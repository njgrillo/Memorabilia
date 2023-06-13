namespace Memorabilia.Application.Features.Admin.People;

public class PersonNicknameEditModel : EditModel
{
    public PersonNicknameEditModel() { }

    public PersonNicknameEditModel(PersonNicknameModel model)
    {
        Id = model.Id;
        Nickname = model.Nickname;
        PersonId = model.PersonId;
    }

    public string Nickname { get; set; }

    public int PersonId { get; set; }
}

namespace Memorabilia.Application.Features.Admin.Management.Nicknames;

public class NicknamesEditModel
{
    public NicknamesEditModel() { }

    public NicknamesEditModel(PersonModel person)
    {
        Nicknames = person.Nicknames
                          .Select(x => new NicknameEditModel(x))
                          .ToList();

        PersonId = person.Id;
    }

    public List<NicknameEditModel> Nicknames { get; set; }
        = [];

    public int PersonId { get; private set; }
}

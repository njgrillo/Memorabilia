namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonNicknameEditor 
{
    [Parameter]
    public List<PersonNicknameEditModel> Nicknames { get; set; } 
        = [];

    protected PersonNicknameEditModel Model 
        = new();

    private List<PersonNicknameEditModel> _nicknames
        => Nicknames.Where(personNickname => !personNickname.IsDeleted)
                    .OrderBy(personNickname => personNickname.Nickname)
                    .ToList();

    private void Add()
    {
        if (Model.Nickname.IsNullOrEmpty())
            return;

        Nicknames.Add(Model);

        Model = new();
    }
}

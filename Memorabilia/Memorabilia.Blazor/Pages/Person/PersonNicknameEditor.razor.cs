namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonNicknameEditor 
{
    [Parameter]
    public List<PersonNicknameEditModel> Nicknames { get; set; } 
        = new();

    protected PersonNicknameEditModel Model 
        = new();

    private void Add()
    {
        if (Model.Nickname.IsNullOrEmpty())
            return;

        Nicknames.Add(Model);

        Model = new();
    }
}

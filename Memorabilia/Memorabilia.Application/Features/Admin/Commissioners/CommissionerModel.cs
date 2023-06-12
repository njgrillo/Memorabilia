namespace Memorabilia.Application.Features.Admin.Commissioners;

public class CommissionerModel : IWithName, IWithValue<int>
{
    private readonly Entity.Commissioner _commissioner;

    public CommissionerModel() { }

    public CommissionerModel(Entity.Commissioner commissioner)
    {
        _commissioner = commissioner;
    }

    public int? BeginYear 
        => _commissioner.BeginYear;

    public int? EndYear 
        => _commissioner.EndYear;

    public int Id 
        => _commissioner.Id;

    string IWithName.Name 
        => Person.DisplayName;

    public Entity.Person Person 
        => _commissioner.Person;

    public int SportLeagueLevelId 
        => _commissioner.SportLeagueLevelId;

    public string SportLeagueLevelName 
        => _commissioner.SportLeagueLevelName;    

    int IWithValue<int>.Value 
        => Id;
}

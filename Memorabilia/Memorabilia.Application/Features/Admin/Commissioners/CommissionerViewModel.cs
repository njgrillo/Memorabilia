using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Commissioners;

public class CommissionerViewModel : IWithName, IWithValue<int>
{
    private readonly Commissioner _commissioner;

    public CommissionerViewModel() { }

    public CommissionerViewModel(Commissioner commissioner)
    {
        _commissioner = commissioner;
    }

    public int? BeginYear => _commissioner.BeginYear;

    public int? EndYear => _commissioner.EndYear;

    public int Id => _commissioner.Id;

    string IWithName.Name => Person.DisplayName;

    public Person Person => _commissioner.Person;

    public int SportLeagueLevelId => _commissioner.SportLeagueLevelId;

    public string SportLeagueLevelName => _commissioner.SportLeagueLevelName;    

    int IWithValue<int>.Value => Id;
}

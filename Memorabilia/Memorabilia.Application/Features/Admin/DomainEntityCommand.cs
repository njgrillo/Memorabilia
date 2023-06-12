namespace Memorabilia.Application.Features.Admin;

public class DomainEntityCommand : DomainCommand, ICommand
{
    private readonly DomainEditModel _model;

    public DomainEntityCommand(DomainEditModel model)
    {
        _model = model;
    }

    public string Abbreviation 
        => _model.Abbreviation;

    public int Id 
        => _model.Id;

    public bool IsDeleted 
        => _model.IsDeleted;

    public bool IsModified 
        => _model.IsModified;

    public bool IsNew 
        => _model.IsNew;

    public string Name 
        => _model.Name;
}

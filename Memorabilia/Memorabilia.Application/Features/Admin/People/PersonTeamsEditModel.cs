namespace Memorabilia.Application.Features.Admin.People;

public class PersonTeamsEditModel : EditModel
{
    public PersonTeamsEditModel() { }

    public PersonTeamsEditModel(PersonTeamsModel model)
    {
        PersonId = model.PersonId;

        SportIds = model.Sports
                        .Select(sport => sport.SportId)
                        .Distinct()
                        .ToList();

        Teams = model.Teams
                     .ToEditModelList()
                     .OrderBy(team => team.BeginYear)
                     .ThenBy(team => team.TeamDisplayName)
                     .ToList();       
    }

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/SportService/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/Accolade/{Constant.EditModeType.Update.Name}/{PersonId}";

    public override Constant.EditModeType EditModeType 
        => Teams.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => Constant.AdminDomainItem.Teams.Title;

    public string MenuItemPath
        => "People";

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} {ItemTitle}";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Team;

    public List<int> SportIds { get; set; } 
        = new();

    public List<PersonTeamEditModel> Teams { get; set; } 
        = new();
}

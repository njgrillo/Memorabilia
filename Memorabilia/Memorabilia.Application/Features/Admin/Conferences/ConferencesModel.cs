namespace Memorabilia.Application.Features.Admin.Conferences;

public class ConferencesModel : Model
{
    public ConferencesModel() { }

    public ConferencesModel(IEnumerable<Entity.Conference> conferences)
    {
        Conferences = conferences.Select(conference => new ConferenceModel(conference))
                                 .OrderBy(conference => conference.SportLeagueLevelName)
                                 .ThenBy(conference => conference.Name)
                                 .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<ConferenceModel> Conferences { get; set; } 
        = new();

    public override string ItemTitle 
        => Constant.AdminDomainItem.Conferences.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Conferences.Title;

    public override string RoutePrefix 
        => Constant.AdminDomainItem.Conferences.Page;
}

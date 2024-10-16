namespace Memorabilia.Application.Features.Admin.Colleges;

public class CollegesModel : Model
{
    public CollegesModel() { }

    public CollegesModel(IEnumerable<Entity.College> colleges)
    {
        Colleges = colleges.Select(college => new CollegeModel(college))
                           .OrderBy(college => college.Name)
                           .ToList();
    }

    public string AddRoute
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public List<CollegeModel> Colleges { get; set; }
        = [];

    public override string ItemTitle 
        => Constant.AdminDomainItem.Colleges.Item;

    public override string PageTitle 
        => Constant.AdminDomainItem.Colleges.Title;

    public override string RoutePrefix
        => Constant.AdminDomainItem.Colleges.Page;
}

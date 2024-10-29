namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

public class InternationalHallOfFamesEditModel : EditModel
{
    public InternationalHallOfFamesEditModel() { }

    public InternationalHallOfFamesEditModel(
        int internationalHallOfFameTypeId, 
        Entity.InternationalHallOfFame[] hallOfFames
        )
    {        
        HallOfFames = hallOfFames.Select(x => new InternationalHallOfFameEditModel(x)).ToList();
        InternationalHallOfFameTypeId = internationalHallOfFameTypeId;
    }

    public List<InternationalHallOfFameEditModel> HallOfFames { get; set; }
        = [];

    public Constant.InternationalHallOfFameType InternationalHallOfFameType { get; set; }

    public int InternationalHallOfFameTypeId { get; set; }

    public string InternationalHallOfFameTypeName
        => Constant.InternationalHallOfFameType.Find(InternationalHallOfFameTypeId)?.Name;    
}

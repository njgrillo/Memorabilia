namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class CerealBoxEditModel : MemorabiliaItemEditModel
{
    public CerealBoxEditModel() 
    {
        BrandId = Constant.Brand.GeneralMills.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public CerealBoxEditModel(CerealBoxModel model)
    {
        BrandId = model.Brand.BrandId;
        CerealTypeId = model.Cereal?.CerealTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SportIds = model.Sports
                        .Select(x => x.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public int CerealTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.CerealBox;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.CerealBox;
}

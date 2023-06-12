namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class BammerEditModel : MemorabiliaItemEditModel
{
    public BammerEditModel() 
    {
        BrandId = Constant.Brand.Salvino.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
    }

    public BammerEditModel(BammerModel model)
    {
        BammerTypeId = model.Bammer?.BammerTypeId ?? 0;
        BrandId = model.Brand.BrandId;
        InPackage = model.Bammer?.InPackage ?? false;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SportId = model.Sports
                       .Select(x => x.SportId)
                       .FirstOrDefault();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();

        Year = model.Bammer?.Year;
    }

    public int BammerTypeId { get; set; }

    public bool CanHaveBammerType 
        => BrandId == Constant.Brand.Salvino.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.Bammer;

    public bool InPackage { get; set; }

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Bammer;

    public int? Year { get; set; }
}

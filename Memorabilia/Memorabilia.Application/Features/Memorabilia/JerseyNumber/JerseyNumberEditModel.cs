namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class JerseyNumberEditModel : MemorabiliaItemEditModel
{
    public JerseyNumberEditModel() { }

    public JerseyNumberEditModel(JerseyNumberModel model)
    {
        MemorabiliaId = model.MemorabiliaId;
        Number = model.Number;

        SportId = model.Sports
                       .Select(sport => sport.SportId)
                       .FirstOrDefault();

        if (model.People.Any())
            Person = model.People.First().Person.ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.JerseyNumber;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.JerseyNumber;

    public int? Number { get; set; }
}

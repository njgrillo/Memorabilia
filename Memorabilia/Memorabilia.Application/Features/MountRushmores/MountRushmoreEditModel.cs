namespace Memorabilia.Application.Features.MountRushmores;

public class MountRushmoreEditModel : EditModel
{
    public MountRushmoreEditModel() { }

    public MountRushmoreEditModel(MountRushmoreModel model)
    {
        Description = model.Description;
        Id = model.Id;
        Name = model.Name;
        People = model.People.Select(mountRushmorePerson => new MountRushmorePersonEditModel(mountRushmorePerson)).ToList();
        PrivacyTypeId = model.PrivacyType?.Id ?? 0;
        UserId = model.UserId;
    }

    public MountRushmoreEditModel(Entity.MountRushmore model)
    {
        Description = model.Description;
        Id = model.Id;  
        Name = model.Name;
        People = model.People.Select(mountRushmorePerson => new MountRushmorePersonEditModel(mountRushmorePerson)).ToList();
        PrivacyTypeId = model.PrivacyTypeId;
        UserId = model.UserId;
    }

    public string Description { get; set; }

    public List<MountRushmorePersonEditModel> People { get; set; }
        = [];

    public int PrivacyTypeId { get; set; }

    public int UserId { get; set; }
}

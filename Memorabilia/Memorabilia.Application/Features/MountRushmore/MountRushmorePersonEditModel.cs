namespace Memorabilia.Application.Features.MountRushmore;

public class MountRushmorePersonEditModel : EditModel
{
    public MountRushmorePersonEditModel()
    {
        
    }

    public MountRushmorePersonEditModel(Entity.MountRushmorePerson mountRushmorePerson)
    {
        MountRushmoreId = mountRushmorePerson.MountRushmoreId;
        PersonId = mountRushmorePerson.PersonId;
        PositionId = mountRushmorePerson.PositionId;
    }

    public MountRushmorePersonEditModel(MountRushmorePersonModel mountRushmorePerson)
    {
        MountRushmoreId = mountRushmorePerson.MountRushmoreId;
        PersonId = mountRushmorePerson.PersonId;
        PositionId = mountRushmorePerson.PositionId;
    }

    public MountRushmorePersonEditModel(int mountRushmoreId, int personId, int positionId)
    {
        MountRushmoreId = mountRushmoreId;
        PersonId = personId;
        PositionId = positionId;
    }

    public int MountRushmoreId { get; set; }

    public int PersonId { get; set; }

    public int PositionId { get; set; }
}

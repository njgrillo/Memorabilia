namespace Memorabilia.Application.Features.MountRushmores;

public class MountRushmorePersonModel
{
    private readonly Entity.MountRushmorePerson _mountRushmorePerson;

    public MountRushmorePersonModel() { }

    public MountRushmorePersonModel(Entity.MountRushmorePerson mountRushmorePerson)
    {
        _mountRushmorePerson = mountRushmorePerson; 
    }

    public int MountRushmoreId
        => _mountRushmorePerson.MountRushmoreId;

    public Entity.Person Person
        => _mountRushmorePerson.Person;

    public int PersonId
        => _mountRushmorePerson.PersonId;

    public int PositionId
        => _mountRushmorePerson.PositionId;
}

namespace Memorabilia.Domain.Entities;

public class MountRushmore : Entity
{
    public MountRushmore() { }

    public MountRushmore(
        string description,
        string name,
        int privacyTypeId,
        int userId)
    {
        Description = description;
        Name = name;
        PrivacyTypeId = privacyTypeId;
        UserId = userId;
    }

    public string Description { get; private set; }

    public string Name { get; private set; }

    public virtual List<MountRushmorePerson> People { get; private set; }
        = [];

    public int PrivacyTypeId { get; private set; }

    public virtual User User { get; set; }

    public int UserId { get; private set; }

    public void Set(
        string description,
        string name,
        int privacyTypeId)
    {
        Description = description;
        Name = name;
        PrivacyTypeId = privacyTypeId;
    }

    public void SetPerson(int personId, int positionId, bool isDeleted)
    {
        MountRushmorePerson mountRushmorePerson = People.SingleOrDefault(person => person.PositionId == positionId);

        if (mountRushmorePerson is null && !isDeleted)
        {
            People.Add(new MountRushmorePerson(Id, personId, positionId));
            return;
        }

        if (isDeleted)
        {
            People.Remove(mountRushmorePerson);
            return;
        }

        mountRushmorePerson.Set(personId, positionId);
    }
}

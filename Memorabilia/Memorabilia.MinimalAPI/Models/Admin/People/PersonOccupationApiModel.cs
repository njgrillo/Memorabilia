namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonOccupationApiModel
{
    private readonly Entity.PersonOccupation _personOccupation;

	public PersonOccupationApiModel(Entity.PersonOccupation personOccupation)
	{
		_personOccupation = personOccupation;
	}

	public string Occupation
		=> Constant.Occupation.Find(_personOccupation.OccupationId).Name;

    public string OccupationType
        => Constant.OccupationType.Find(_personOccupation.OccupationTypeId).Name;
}

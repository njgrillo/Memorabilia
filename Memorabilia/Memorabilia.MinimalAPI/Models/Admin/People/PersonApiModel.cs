namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonApiModel
{
	private readonly Entity.Person _person;

    public PersonApiModel()
    {
        _person = new Entity.Person();
    }

	public PersonApiModel(Entity.Person person)
	{
		_person = person;
	}

    public PersonAccomplishmentApiModel[] Accomplishments
        => _person.Accomplishments
                  .Select(x => new PersonAccomplishmentApiModel(x))
                  .ToArray() ?? Array.Empty<PersonAccomplishmentApiModel>();

    public PersonAllStarApiModel[] AllStars
        => _person.AllStars
                  .Select(x => new PersonAllStarApiModel(x))
                  .ToArray() ?? Array.Empty<PersonAllStarApiModel>();

    public PersonAwardApiModel[] Awards
        => _person.Awards
                  .Select(x => new PersonAwardApiModel(x))
                  .ToArray() ?? Array.Empty<PersonAwardApiModel>();

    public string? BirthDate
		=> _person.BirthDate?.ToShortDateString();

	public string CallingName
		=> _person.Nickname;

    public PersonCareerRecordApiModel[] CareerRecords
        => _person.CareerRecords
                  .Select(x => new PersonCareerRecordApiModel(x))
                  .ToArray() ?? Array.Empty<PersonCareerRecordApiModel>();

    public PersonCollegeHallOfFameApiModel[] CollegeHallOfFames
        => _person.CollegeHallOfFames
                  .Select(x => new PersonCollegeHallOfFameApiModel(x))
                  .ToArray() ?? Array.Empty<PersonCollegeHallOfFameApiModel>();

    public PersonCollegeRetiredNumberApiModel[] CollegeRetiredNumbers
        => _person.CollegeRetiredNumbers
                  .Select(x => new PersonCollegeRetiredNumberApiModel(x))
                  .ToArray() ?? Array.Empty<PersonCollegeRetiredNumberApiModel>();

    public PersonCollegeApiModel[] Colleges
        => _person.Colleges
                  .Select(x => new PersonCollegeApiModel(x))
                  .ToArray() ?? Array.Empty<PersonCollegeApiModel>();

    public string? DeathDate
        => _person.DeathDate?.ToShortDateString();

    public string DisplayName 
		=> _person.DisplayName;

    public PersonDraftApiModel[] Drafts
        => _person.Drafts
                  .Select(x => new PersonDraftApiModel(x))
                  .ToArray() ?? Array.Empty<PersonDraftApiModel>();

    public string FirstName
		=> _person.FirstName;

    public PersonFranchiseHallOfFameApiModel[] FranchiseHallOfFames
        => _person.FranchiseHallOfFames
                  .Select(x => new PersonFranchiseHallOfFameApiModel(x))
                  .ToArray() ?? Array.Empty<PersonFranchiseHallOfFameApiModel>();

    public PersonFranchiseRetiredNumberApiModel[] FranchiseRetiredNumbers
        => _person.RetiredNumbers
                  .Select(x => new PersonFranchiseRetiredNumberApiModel(x))
                  .ToArray() ?? Array.Empty<PersonFranchiseRetiredNumberApiModel>();

    public PersonHallOfFameApiModel[] HallOfFames
        => _person.HallOfFames
                  .Select(x => new PersonHallOfFameApiModel(x))
                  .ToArray() ?? Array.Empty<PersonHallOfFameApiModel>();

    public string ImageData { get; set; }

    public PersonInternationalHallOfFameApiModel[] InternationalHallOfFames
        => _person.InternationalHallOfFames
                  .Select(x => new PersonInternationalHallOfFameApiModel(x))
                  .ToArray() ?? Array.Empty<PersonInternationalHallOfFameApiModel>();

    public string LastName
		=> _person.LastName;

    public PersonLeaderApiModel[] Leaders
        => _person.Leaders
                  .Select(x => new PersonLeaderApiModel(x))
                  .ToArray() ?? Array.Empty<PersonLeaderApiModel>();

    public string LegalName
		=> _person.LegalName;

	public string MiddleName
		=> _person.MiddleName;

	public PersonNicknameApiModel[] Nicknames
		=> _person.Nicknames
				  .Select(x => new PersonNicknameApiModel(x))
			      .ToArray() ?? Array.Empty<PersonNicknameApiModel>();

    public PersonOccupationApiModel[] Occupations
        => _person.Occupations
                  .Select(x => new PersonOccupationApiModel(x))
                  .ToArray() ?? Array.Empty<PersonOccupationApiModel>();

    public PersonPositionApiModel[] Positions
        => _person.Positions
                  .Select(x => new PersonPositionApiModel(x))
                  .ToArray() ?? Array.Empty<PersonPositionApiModel>();

    public string ProfileName
		=> _person.ProfileName;

    public PersonSingleSeasonRecordApiModel[] SingleSeasonRecords
        => _person.SingleSeasonRecords
                  .Select(x => new PersonSingleSeasonRecordApiModel(x))
                  .ToArray() ?? Array.Empty<PersonSingleSeasonRecordApiModel>();

    public PersonSportApiModel[] Sports
        => _person.Sports
                  .Select(x => new PersonSportApiModel(x))
                  .ToArray() ?? Array.Empty<PersonSportApiModel>();

    public PersonSportServiceApiModel SportService
        => _person.Service != null 
        ? new(_person.Service)
        : new();

    public string Suffix 
		=> _person.Suffix;

    public PersonTeamApiModel[] Teams
        => _person.Teams
                  .Select(x => new PersonTeamApiModel(x))
                  .ToArray() ?? Array.Empty<PersonTeamApiModel>();
}

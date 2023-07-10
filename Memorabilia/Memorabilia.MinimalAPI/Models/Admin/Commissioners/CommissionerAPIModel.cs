namespace Memorabilia.MinimalAPI.Models.Admin.Commissioners;

public class CommissionerApiModel
{
	private readonly Entity.Commissioner _commissioner;

	public CommissionerApiModel(Entity.Commissioner commissioner)
	{
		_commissioner = commissioner;
	}

	public int? BeginYear 
		=> _commissioner.BeginYear;

	public int? EndYear 
		=> _commissioner.EndYear;

	public string Person 
		=> _commissioner.Person.ProfileName;

	public string Sport
		=> Constant.SportLeagueLevel.Find(_commissioner.SportLeagueLevelId).Sport.Name;

	public string SportLeagueLevel 
		=> _commissioner.SportLeagueLevelName;
}

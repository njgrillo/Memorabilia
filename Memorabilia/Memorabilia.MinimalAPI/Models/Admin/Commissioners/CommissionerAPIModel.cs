namespace Memorabilia.MinimalAPI.Models.Admin.Commissioners;

public class CommissionerApiModel(Entity.Commissioner commissioner)
{
    public int? BeginYear 
		=> commissioner.BeginYear;

	public int? EndYear 
		=> commissioner.EndYear;

	public string Person 
		=> commissioner.Person.ProfileName;

	public string Sport
		=> Constant.SportLeagueLevel.Find(commissioner.SportLeagueLevelId).Sport.Name;

	public string SportLeagueLevel 
		=> commissioner.SportLeagueLevelName;
}

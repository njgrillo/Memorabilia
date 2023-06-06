namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class FootballProfileRule : IProfileRule
{
    public bool Applies(Entity.Person person, Entity.PersonOccupation occupation)
        => Constant.Occupation.IsSportOccupation(occupation.OccupationId) 
        && person.Sports.Any(sport => sport.SportId == Constant.Sport.Football.Id);

    public Constant.ProfileType GetProfileType()
        => Constant.ProfileType.Football;
}

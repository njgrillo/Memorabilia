namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class BaseballProfileRule : IProfileRule
{
    public bool Applies(Entity.Person person, Entity.PersonOccupation occupation)
        => Constant.Occupation.IsBaseballOccupation(occupation.OccupationId) && 
           person.Sports.Any(sport => sport.SportId == Constant.Sport.Baseball.Id);

    public Constant.ProfileType GetProfileType()
        => Constant.ProfileType.Baseball;
}

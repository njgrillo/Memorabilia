namespace Memorabilia.Application.Services.Tools.Profile.Rules;

public class HockeyProfileRule : IProfileRule
{
    public bool Applies(Entity.Person person, Entity.PersonOccupation occupation)
        => Constant.Occupation.IsSportOccupation(occupation.OccupationId) &&
           person.Sports.Any(sport => sport.SportId == Constant.Sport.Hockey.Id);

    public Constant.ProfileType GetProfileType()
        => Constant.ProfileType.Hockey;
}

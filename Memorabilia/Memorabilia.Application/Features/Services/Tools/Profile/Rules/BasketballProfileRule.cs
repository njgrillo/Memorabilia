namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public class BasketballProfileRule : IProfileRule
{
    public bool Applies(Entity.Person person, Entity.PersonOccupation occupation)
        => Constant.Occupation.IsSportOccupation(occupation.OccupationId) && 
           person.Sports.Any(sport => sport.SportId == Constant.Sport.Basketball.Id);

    public Constant.ProfileType GetProfileType()
        => Constant.ProfileType.Basketball;
}

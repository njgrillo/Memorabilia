namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public interface IProfileRule
{
    bool Applies(Entity.Person person, Entity.PersonOccupation occupation);

    Constant.ProfileType GetProfileType();
}

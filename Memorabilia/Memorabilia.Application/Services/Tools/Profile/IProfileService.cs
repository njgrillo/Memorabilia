namespace Memorabilia.Application.Services.Tools.Profile;

public interface IProfileService
{
    Constant.ProfileType[] GetProfileTypes(Entity.Person person, Entity.PersonOccupation occupation);
}

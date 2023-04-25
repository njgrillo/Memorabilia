using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Tools.Profile;

public interface IProfileService
{
    ProfileType[] GetProfileTypes(Domain.Entities.Person person, Domain.Entities.PersonOccupation occupation);
}

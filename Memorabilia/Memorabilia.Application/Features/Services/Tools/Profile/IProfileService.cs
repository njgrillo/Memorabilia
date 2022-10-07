using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Services.Tools.Profile;

public interface IProfileService
{
    Task<List<ProfileType>> GetProfileTypes(int personId);
}

using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Services.Tools.Profile
{
    public interface IProfileService
    {
        Task<List<ProfileType>> GetProfileTypes(int personId);
    }
}

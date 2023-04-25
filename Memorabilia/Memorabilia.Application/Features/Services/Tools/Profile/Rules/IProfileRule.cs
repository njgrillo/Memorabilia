using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Services.Tools.Profile.Rules;

public interface IProfileRule
{
    bool Applies(Person person, PersonOccupation occupation);

    ProfileType GetProfileType();
}

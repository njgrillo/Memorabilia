namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Awards.Rules;

public interface IAwardRule
{
    bool Applies(Domain.Constants.AwardType awardType);

    string[] GenerateInscriptions(Domain.Entities.PersonAward[] awards);
}

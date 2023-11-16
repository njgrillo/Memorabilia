namespace Memorabilia.Application.Services.Autographs.Inscriptions.Awards.Rules;

public interface IAwardRule
{
    bool Applies(Constant.AwardType awardType);

    string[] GenerateInscriptions(Entity.PersonAward[] awards);
}

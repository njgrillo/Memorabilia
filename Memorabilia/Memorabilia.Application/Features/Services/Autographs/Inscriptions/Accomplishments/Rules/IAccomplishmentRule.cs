namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public interface IAccomplishmentRule
{
    bool Applies(Domain.Constants.AccomplishmentType accomplishmentType);

    string[] GenerateInscriptions(Domain.Entities.PersonAccomplishment[] accomplishments);
}

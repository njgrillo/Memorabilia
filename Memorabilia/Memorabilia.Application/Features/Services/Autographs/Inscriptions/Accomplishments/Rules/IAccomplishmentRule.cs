﻿namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions.Accomplishments.Rules;

public interface IAccomplishmentRule
{
    bool Applies(Constant.AccomplishmentType accomplishmentType);

    string[] GenerateInscriptions(Entity.PersonAccomplishment[] accomplishments);
}

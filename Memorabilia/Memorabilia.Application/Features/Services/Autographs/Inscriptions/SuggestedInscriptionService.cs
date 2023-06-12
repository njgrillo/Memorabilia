﻿namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions;

public class SuggestedInscriptionService
{
	private readonly AccomplishmentRuleFactory _accomplishmentRuleFactory;
	private readonly AwardRuleFactory _awardRuleFactory;
    private Entity.Person _person;

	public SuggestedInscriptionService(AccomplishmentRuleFactory accomplishmentRuleFactory,
		                               AwardRuleFactory awardRuleFactory)
	{
		_accomplishmentRuleFactory = accomplishmentRuleFactory;
		_awardRuleFactory = awardRuleFactory;
    }

	public SuggestedInscriptionModel[] GenerateInscriptions(Entity.Person person)
	{
        _person = person;

        var inscriptions = new List<SuggestedInscriptionModel>();

        Constant.AccomplishmentType[] accomplishmentTypes
            = _person.Accomplishments
                     .DistinctBy(x => x.AccomplishmentTypeId)
                     .Select(x => Constant.AccomplishmentType.Find(x.AccomplishmentTypeId))
                     .ToArray();

		if (accomplishmentTypes.Any())
			inscriptions.AddRange(GenerateAccomplishmentInscriptions(accomplishmentTypes));

        if (_person.AllStars.Any())
            inscriptions.AddRange(GenerateAllStarInscriptions(_person.AllStars.ToArray()));

        Constant.AwardType[] awardTypes
            = _person.Awards
                     .DistinctBy(x => x.AwardTypeId)
                     .Select(x => Constant.AwardType.Find(x.AwardTypeId))
                     .ToArray();

        if (awardTypes.Any())
            inscriptions.AddRange(GenerateAwardInscriptions(awardTypes));

        if (_person.Drafts.Any())
            inscriptions.AddRange(GenerateDraftInscriptions(_person.Drafts.ToArray()));

        if (_person.HallOfFames.Any())
            inscriptions.AddRange(GenerateHallOfFameInscriptions(_person.HallOfFames.ToArray()));

        if (_person.Nicknames.Any())
            inscriptions.AddRange(GenerateNicknameInscriptions(_person.Nicknames.ToArray()));

        return inscriptions.ToArray();
	}

	private SuggestedInscriptionModel[] GenerateAccomplishmentInscriptions(Constant.AccomplishmentType[] accomplishmentTypes)
	{
		var inscriptions = new List<SuggestedInscriptionModel>();

		foreach (Constant.AccomplishmentType accomplishmentType in accomplishmentTypes)
		{
            foreach (var rule in _accomplishmentRuleFactory.Rules)
            {
                if (rule.Applies(accomplishmentType))
                {
					Entity.PersonAccomplishment[] accomplishments 
						= _person.Accomplishments.Where(x => x.AccomplishmentTypeId == accomplishmentType.Id)
												 .ToArray();

					if (!accomplishments.Any())
						continue;

                    string[] items = rule.GenerateInscriptions(accomplishments);

					if (items.Any())
					{
						inscriptions.AddRange(items.Select(item => new SuggestedInscriptionModel
							{
								InscriptionType = Constant.InscriptionType.Accomplishment,
								Text = item
							})
						);
					}
                }
            }
        }

		return inscriptions.ToArray();
	}

    private static SuggestedInscriptionModel[] GenerateAllStarInscriptions(Entity.AllStar[] allStars)
    {
        var inscriptions = new List<SuggestedInscriptionModel>
        {
            new SuggestedInscriptionModel
            {
                InscriptionType = Constant.InscriptionType.Other,
                Text = $"{allStars.Length}x All Star"
            }
        };

        inscriptions.AddRange(allStars.Select(x => new SuggestedInscriptionModel
            {
                InscriptionType = Constant.InscriptionType.Other,
                Text = $"{x.Year} All Star"
            })
        );

        return inscriptions.ToArray();
    }

    private SuggestedInscriptionModel[] GenerateAwardInscriptions(Constant.AwardType[] awardTypes)
    {
        var inscriptions = new List<SuggestedInscriptionModel>();

        foreach (Constant.AwardType awardType in awardTypes)
        {
            foreach (var rule in _awardRuleFactory.Rules)
            {
                if (rule.Applies(awardType))
                {
                    Entity.PersonAward[] awards
                        = _person.Awards.Where(x => x.AwardTypeId == awardType.Id)
                                        .ToArray();

                    if (!awards.Any())
                        continue;

                    string[] items = rule.GenerateInscriptions(awards);

                    if (items.Any())
                    {
                        inscriptions.AddRange(items.Select(item => new SuggestedInscriptionModel
                            {
                                InscriptionType = Constant.InscriptionType.Award,
                                Text = item
                            })
                        );
                    }
                }
            }
        }

        return inscriptions.ToArray();
    }

    private static SuggestedInscriptionModel[] GenerateDraftInscriptions(Entity.Draft[] drafts)
    {
        var inscriptions = new List<SuggestedInscriptionModel>();
 
        if (drafts.Any(draft => draft.Round == 1))
        {
            inscriptions.Add(new SuggestedInscriptionModel 
            {
                InscriptionType = Constant.InscriptionType.Draft,
                Text = "1st Round Pick"
            });
        }

        return inscriptions.ToArray();
    }

    private static SuggestedInscriptionModel[] GenerateHallOfFameInscriptions(Entity.HallOfFame[] hallOfFames)
    {
        var inscriptions = new List<SuggestedInscriptionModel>();

        inscriptions.AddRange(hallOfFames.Select(hof => new SuggestedInscriptionModel
            {
                InscriptionType = Constant.InscriptionType.HallOfFame,
                Text = $"HOF{(hof.InductionYear.HasValue ? " " + hof.InductionYear.Value.ToString()[2..] : "")}"
            })
        );

        inscriptions.AddRange(hallOfFames.Select(hof => new SuggestedInscriptionModel
            {
                InscriptionType = Constant.InscriptionType.HallOfFame,
                Text = $"HOF{(hof.InductionYear.HasValue ? " " + hof.InductionYear.Value : "")}"
            })
        );        

        return inscriptions.DistinctBy(x => x.Text)
                           .ToArray();
    }

    private static SuggestedInscriptionModel[] GenerateNicknameInscriptions(Entity.PersonNickname[] nicknames)
    {
        var inscriptions = new List<SuggestedInscriptionModel>();

        inscriptions.AddRange(nicknames.Select(nickname => new SuggestedInscriptionModel
            {
                InscriptionType = Constant.InscriptionType.Nickname,
                Text = nickname.Nickname
            })
        );

        return inscriptions.ToArray();
    }
}

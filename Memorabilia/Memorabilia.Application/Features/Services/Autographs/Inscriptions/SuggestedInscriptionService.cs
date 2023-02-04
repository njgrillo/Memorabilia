using Memorabilia.Domain.Entities;
using static MudBlazor.CategoryTypes;

namespace Memorabilia.Application.Features.Services.Autographs.Inscriptions;

public class SuggestedInscriptionService
{
	private readonly AccomplishmentRuleFactory _accomplishmentRuleFactory;
	private readonly AwardRuleFactory _awardRuleFactory;
    private Domain.Entities.Person _person;

	public SuggestedInscriptionService(AccomplishmentRuleFactory accomplishmentRuleFactory,
		AwardRuleFactory awardRuleFactory)
	{
		_accomplishmentRuleFactory = accomplishmentRuleFactory;
		_awardRuleFactory = awardRuleFactory;
    }

	public SuggestedInscriptionViewModel[] GenerateInscriptions(Domain.Entities.Person person)
	{
        _person = person;

        var inscriptions = new List<SuggestedInscriptionViewModel>();

        Domain.Constants.AccomplishmentType[] accomplishmentTypes
            = _person.Accomplishments
                     .DistinctBy(x => x.AccomplishmentTypeId)
                     .Select(x => Domain.Constants.AccomplishmentType.Find(x.AccomplishmentTypeId))
                     .ToArray();

		if (accomplishmentTypes.Any())
			inscriptions.AddRange(GenerateAccomplishmentInscriptions(accomplishmentTypes));

        if (_person.AllStars.Any())
            inscriptions.AddRange(GenerateAllStarInscriptions(_person.AllStars.ToArray()));

        Domain.Constants.AwardType[] awardTypes
            = _person.Awards
                     .DistinctBy(x => x.AwardTypeId)
                     .Select(x => Domain.Constants.AwardType.Find(x.AwardTypeId))
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

	private SuggestedInscriptionViewModel[] GenerateAccomplishmentInscriptions(Domain.Constants.AccomplishmentType[] accomplishmentTypes)
	{
		var inscriptions = new List<SuggestedInscriptionViewModel>();

		foreach (Domain.Constants.AccomplishmentType accomplishmentType in accomplishmentTypes)
		{
            foreach (var rule in _accomplishmentRuleFactory.Rules)
            {
                if (rule.Applies(accomplishmentType))
                {
					Domain.Entities.PersonAccomplishment[] accomplishments 
						= _person.Accomplishments.Where(x => x.AccomplishmentTypeId == accomplishmentType.Id)
												 .ToArray();

					if (!accomplishments.Any())
						continue;

                    string[] items = rule.GenerateInscriptions(accomplishments);

					if (items.Any())
					{
						inscriptions.AddRange(items.Select(item => new SuggestedInscriptionViewModel
							{
								InscriptionType = Domain.Constants.InscriptionType.Accomplishment,
								Text = item
							})
						);
					}
                }
            }
        }

		return inscriptions.ToArray();
	}

    private static SuggestedInscriptionViewModel[] GenerateAllStarInscriptions(AllStar[] allStars)
    {
        var inscriptions = new List<SuggestedInscriptionViewModel>
        {
            new SuggestedInscriptionViewModel
            {
                InscriptionType = Domain.Constants.InscriptionType.Other,
                Text = $"{allStars.Length}x All Star"
            }
        };

        inscriptions.AddRange(allStars.Select(x => new SuggestedInscriptionViewModel
        {
            InscriptionType = Domain.Constants.InscriptionType.Other,
            Text = $"{x.Year} All Star"
        })
        );

        return inscriptions.ToArray();
    }

    private SuggestedInscriptionViewModel[] GenerateAwardInscriptions(Domain.Constants.AwardType[] awardTypes)
    {
        var inscriptions = new List<SuggestedInscriptionViewModel>();

        foreach (Domain.Constants.AwardType awardType in awardTypes)
        {
            foreach (var rule in _awardRuleFactory.Rules)
            {
                if (rule.Applies(awardType))
                {
                    Domain.Entities.PersonAward[] awards
                        = _person.Awards.Where(x => x.AwardTypeId == awardType.Id)
                                        .ToArray();

                    if (!awards.Any())
                        continue;

                    string[] items = rule.GenerateInscriptions(awards);

                    if (items.Any())
                    {
                        inscriptions.AddRange(items.Select(item => new SuggestedInscriptionViewModel
                        {
                            InscriptionType = Domain.Constants.InscriptionType.Award,
                            Text = item
                        })
                        );
                    }
                }
            }
        }

        return inscriptions.ToArray();
    }

    private static SuggestedInscriptionViewModel[] GenerateDraftInscriptions(Domain.Entities.Draft[] drafts)
    {
        var inscriptions = new List<SuggestedInscriptionViewModel>();
 
        if (drafts.Any(draft => draft.Round == 1))
        {
            inscriptions.Add(new SuggestedInscriptionViewModel 
            {
                InscriptionType = Domain.Constants.InscriptionType.Draft,
                Text = "1st Round Pick"
            });
        }

        return inscriptions.ToArray();
    }

    private static SuggestedInscriptionViewModel[] GenerateHallOfFameInscriptions(Domain.Entities.HallOfFame[] hallOfFames)
    {
        var inscriptions = new List<SuggestedInscriptionViewModel>();

        inscriptions.AddRange(hallOfFames.Select(hof => new SuggestedInscriptionViewModel
        {
            InscriptionType = Domain.Constants.InscriptionType.HallOfFame,
            Text = $"HOF{(hof.InductionYear.HasValue ? " " + hof.InductionYear.Value.ToString()[2..] : "")}"
        })
        );

        inscriptions.AddRange(hallOfFames.Select(hof => new SuggestedInscriptionViewModel
        {
            InscriptionType = Domain.Constants.InscriptionType.HallOfFame,
            Text = $"HOF{(hof.InductionYear.HasValue ? " " + hof.InductionYear.Value : "")}"
        })
        );        

        return inscriptions.DistinctBy(x => x.Text)
                           .ToArray();
    }

    private static SuggestedInscriptionViewModel[] GenerateNicknameInscriptions(Domain.Entities.PersonNickname[] nicknames)
    {
        var inscriptions = new List<SuggestedInscriptionViewModel>();

        inscriptions.AddRange(nicknames.Select(nickname => new SuggestedInscriptionViewModel
        {
            InscriptionType = Domain.Constants.InscriptionType.Nickname,
            Text = nickname.Nickname
        })
        );

        return inscriptions.ToArray();
    }
}

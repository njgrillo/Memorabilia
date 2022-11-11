﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAwardViewModel : SaveViewModel
{
    public SavePersonAwardViewModel() { }

    public SavePersonAwardViewModel(PersonAward award)
    {
        AwardType = Domain.Constants.AwardType.Find(award.AwardTypeId);
        Id = award.Id;
        PersonId = award.PersonId;
        SportIds = award.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevel.SportId).Distinct().ToArray();
        Year = award.Year;
    }

    public Domain.Constants.AwardType AwardType { get; set; }

    public string AwardTypeName => AwardType?.Name;

    public int PersonId { get; set; }

    public int[] SportIds { get; }

    public int Year { get; set; }
}

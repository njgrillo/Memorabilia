﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Colleges;

public class PersonCollegeViewModel : PersonSportToolViewModel
{
    private readonly PersonCollege _personCollege;

    public PersonCollegeViewModel(PersonCollege personCollege, Domain.Constants.Sport sport)
    {
        _personCollege = personCollege;
        Sport = sport;
    }    

    public string BeginYear => _personCollege.BeginYear.HasValue ? _personCollege.BeginYear.ToString() : string.Empty;

    public int CollegeId => _personCollege.CollegeId;

    public string CollegeName => Domain.Constants.College.Find(CollegeId)?.Name;

    public string EndYear => _personCollege.EndYear.HasValue ? _personCollege.EndYear.ToString() : string.Empty;

    public override int PersonId => _personCollege.PersonId;

    public override string PersonImageFileName => _personCollege.Person.ImageFileName;

    public override string PersonName => _personCollege.Person.DisplayName;
}

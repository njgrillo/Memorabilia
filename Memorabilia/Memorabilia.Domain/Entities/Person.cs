namespace Memorabilia.Domain.Entities;

public class Person : Entity, IWithName
{
    public Person() { }

    public Person(Person person)
    {
        Occupations = person.Occupations;
        Positions = person.Positions;
        Sports = person.Sports;
    }

    public Person(string firstName, 
                  string lastName, 
                  string middleName,
                  string suffix,
                  string nickname,
                  string legalName,
                  string displayName,   
                  string profileName,
                  DateTime? birthDate, 
                  DateTime? deathDate,
                  string[] nicknames)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Suffix = suffix;
        Nickname = nickname;
        LegalName = legalName;
        DisplayName = displayName;
        ProfileName = profileName;
        BirthDate = birthDate;
        DeathDate = deathDate;
        CreateDate = DateTime.UtcNow;

        if (nicknames.HasAny())
            Nicknames = nicknames.Select(nickname => new PersonNickname(Id, nickname)).ToList();
    }

    public virtual List<PersonAccomplishment> Accomplishments { get; private set; } 
        = [];

    public virtual List<AllStar> AllStars { get; private set; } 
        = [];

    public virtual List<PersonAward> Awards { get; private set; } 
        = [];

    public DateTime? BirthDate { get; private set; }

    public virtual List<CareerFranchiseRecord> CareerFranchiseRecords { get; private set; }
        = [];

    public virtual List<CareerRecord> CareerRecords { get; private set; } 
        = [];

    public virtual List<CollegeHallOfFame> CollegeHallOfFames { get; private set; } 
        = [];

    public virtual List<CollegeRetiredNumber> CollegeRetiredNumbers { get; private set; } 
        = [];

    public virtual List<PersonCollege> Colleges { get; private set; } 
        = [];

    public DateTime CreateDate { get; private set; }

    public DateTime? DeathDate { get; private set; }

    public string DisplayName { get; private set; }

    public virtual List<Draft> Drafts { get; private set; }
        = [];

    public string FirstName { get; private set; }

    public virtual List<FranchiseHallOfFame> FranchiseHallOfFames { get; private set; } 
        = [];    

    public virtual List<HallOfFame> HallOfFames { get; private set; } 
        = [];

    public string ImageFileName { get; private set; }

    public virtual List<InternationalHallOfFame> InternationalHallOfFames { get; private set; } 
        = [];

    public DateTime? LastModifiedDate { get; private set; }

    public string LastName { get; private set; }

    public virtual List<Leader> Leaders { get; private set; } 
        = [];

    public string LegalName { get; private set; }

    public string MiddleName { get; private set; }

    public string Name 
        => ProfileName;

    public string Nickname { get; private set; }

    public virtual List<PersonNickname> Nicknames { get; private set; } 
        = [];

    public virtual List<PersonOccupation> Occupations { get; private set; } 
        = [];

    public virtual List<PersonPosition> Positions { get; private set; } 
        
        = [];

    public string ProfileName { get; private set; }

    public virtual List<RetiredNumber> RetiredNumbers { get; private set; } 
        = [];

    public virtual SportService Service { get; private set; }

    public virtual List<SingleSeasonFranchiseRecord> SingleSeasonFranchiseRecords { get; private set; }
        = [];

    public virtual List<SingleSeasonRecord> SingleSeasonRecords { get; private set; } 
        = [];

    public virtual List<PersonSport> Sports { get; private set; } 
        = [];

    public virtual List<PersonTeam> Teams { get; private set; } 
        = [];

    public string Suffix { get; private set; }

    public void RemoveAccomplishments(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Accomplishments.RemoveAll(accomplishment => ids.Contains(accomplishment.Id));
    }

    public void RemoveAllStars(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        AllStars.RemoveAll(allStar => ids.Contains(allStar.Id));
    }

    public void RemoveAwards(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Awards.RemoveAll(award => ids.Contains(award.Id));
    }

    public void RemoveCareerFranchiseRecords(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        CareerFranchiseRecords.RemoveAll(careerFranchiseRecord => ids.Contains(careerFranchiseRecord.Id));
    }

    public void RemoveCareerRecords(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        CareerRecords.RemoveAll(record => ids.Contains(record.Id));
    }

    public void RemoveCollegeHallOfFames(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        CollegeHallOfFames.RemoveAll(hof => ids.Contains(hof.Id));
    }

    public void RemoveCollegeRetiredNumbers(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        CollegeRetiredNumbers.RemoveAll(retiredNumber => ids.Contains(retiredNumber.Id));
    }

    public void RemoveColleges(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Colleges.RemoveAll(college => ids.Contains(college.Id));
    }

    public void RemoveDrafts(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Drafts.RemoveAll(draft => ids.Contains(draft.Id));
    }

    public void RemoveFranchiseHallOfFames(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        FranchiseHallOfFames.RemoveAll(hof => ids.Contains(hof.Id));
    }    

    public void RemoveHallOfFames(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        HallOfFames.RemoveAll(hof => ids.Contains(hof.Id));
    }

    public void RemoveInternationalHallOfFames(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        InternationalHallOfFames.RemoveAll(hof => ids.Contains(hof.Id));
    }

    public void RemoveLeaders(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Leaders.RemoveAll(leader => ids.Contains(leader.Id));
    }

    public void RemoveNicknames(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Nicknames.RemoveAll(nickname => ids.Contains(nickname.Id));
    }

    public void RemoveOccupations(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Occupations.RemoveAll(occupation => ids.Contains(occupation.Id));
    }

    public void RemovePositions(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Positions.RemoveAll(position => ids.Contains(position.Id));
    }

    public void RemoveRetiredNumbers(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        RetiredNumbers.RemoveAll(retiredNumber => ids.Contains(retiredNumber.Id));
    }

    public void RemoveSingleSeasonFranchiseRecords(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        SingleSeasonFranchiseRecords.RemoveAll(singleSeasonFranchiseRecord => ids.Contains(singleSeasonFranchiseRecord.Id));
    }

    public void RemoveSingleSeasonRecords(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        SingleSeasonRecords.RemoveAll(record => ids.Contains(record.Id));
    }

    public void RemoveSports(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Sports.RemoveAll(sport => ids.Contains(sport.Id));
    }

    public void RemoveTeams(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Teams.RemoveAll(team => ids.Contains(team.Id));
    }

    public void Set(string firstName, 
                    string lastName, 
                    string middleName,
                    string suffix,
                    string nickname,
                    string legalName,
                    string displayName,   
                    string profileName,
                    DateTime? birthDate, 
                    DateTime? deathDate,
                    string[] nicknames)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Suffix = suffix;
        Nickname = nickname;
        LegalName = legalName;
        DisplayName = displayName;
        ProfileName = profileName;
        BirthDate = birthDate;
        DeathDate = deathDate;
        LastModifiedDate = DateTime.UtcNow;

        SetNicknames(nicknames);
    }    

    public void SetAccomplishments(int accomplishmentId, int accomplishmentTypeId, DateTime? date, int? year)
    {
        if (accomplishmentId == 0)
        {
            Accomplishments.Add(new PersonAccomplishment(Id, accomplishmentTypeId, date, year));
            return;
        }

        var accomplishment = Accomplishments.Single(accomplishment => accomplishment.Id == accomplishmentId);

        accomplishment.Set(accomplishmentTypeId, date, year);
    }

    public void SetAllStars(int allStarId, int sportId, int? sportLeagueLevelId, int year)
    {
        if (allStarId == 0)
        {
            AllStars.Add(new AllStar(Id, sportId, sportLeagueLevelId, year));
            return;
        }

        var allStar = AllStars.Single(item => item.Id == allStarId);

        allStar.Set(sportId, sportLeagueLevelId, year);
    }

    public void SetAward(int awardId, int awardTypeId, int year)
    {
        if (awardId == 0)
        {
            Awards.Add(new PersonAward(Id, awardTypeId, year));
            return;
        }

        var award = Awards.Single(award => award.Id == awardId);

        award.Set(awardTypeId, year);
    }

    public void SetCareerFranchiseRecord(int careerFranchiseRecordId, int franchiseId, string record, int recordTypeId)
    {
        if (careerFranchiseRecordId == 0)
        {
            CareerFranchiseRecords.Add(new CareerFranchiseRecord(Id, recordTypeId, franchiseId, record));
            return;
        }

        var careerFranchiseRecord = CareerFranchiseRecords.Single(careerFranchiseRecord => careerFranchiseRecord.Id == careerFranchiseRecordId);

        careerFranchiseRecord.Set(Id, record, recordTypeId);
    }

    public void SetCareerRecord(int careerRecordId, int recordTypeId, string record)
    {
        if (careerRecordId == 0)
        {
            CareerRecords.Add(new CareerRecord(Id, recordTypeId, record));
            return;
        }

        CareerRecords.Single(record => record.Id == careerRecordId).Set(recordTypeId, record);
    }

    public void SetCollege(int personCollegeId, int collegeId, int? beginYear, int? endYear)
    {
        var college = personCollegeId > 0
            ? Colleges.SingleOrDefault(college => college.Id == personCollegeId)
            : Colleges.SingleOrDefault(college => college.CollegeId == collegeId);

        if (college == null)
        {
            Colleges.Add(new PersonCollege(Id, collegeId, beginYear, endYear));
            return;
        }

        college.Set(collegeId, beginYear, endYear);
    }

    public void SetCollegeHallOfFame(int collegeId, int sportId, int? year)
    {
        var hallOfFame = CollegeHallOfFames.SingleOrDefault(hof => hof.CollegeId == collegeId && hof.SportId == sportId);

        if (hallOfFame == null)
        {
            CollegeHallOfFames.Add(new CollegeHallOfFame(Id, collegeId, sportId, year));
            return;
        }

        hallOfFame.Set(collegeId, sportId, year);
    }

    public void SetCollegeRetiredNumber(int collegeRetiredNumberId, int collegeId, int playerNumber)
    {
        if (collegeRetiredNumberId == 0)
        {
            CollegeRetiredNumbers.Add(new CollegeRetiredNumber(Id, collegeId, playerNumber));
            return;
        }

        var collegeRetiredNumber = CollegeRetiredNumbers.Single(number => number.Id == collegeRetiredNumberId);

        collegeRetiredNumber.Set(collegeId, playerNumber);
    }

    public void SetDraft(int draftId, int franchiseId, int year, int round, int? pick, int? overall)
    {
        var draft = draftId > 0 
            ? Drafts.SingleOrDefault(draft => draft.Id == draftId)
            : Drafts.SingleOrDefault(draft => draft.FranchiseId == franchiseId && draft.Year == year);

        if (draft == null)
        {
            Drafts.Add(new Draft(Id, franchiseId, year, round, pick, overall));
            return;
        }

        draft.Set(franchiseId, year, round, pick, overall);
    }

    public void SetFranchiseHallOfFame(int franchiseId, int? year)
    {
        var hallOfFame = FranchiseHallOfFames.SingleOrDefault(hof => hof.FranchiseId == franchiseId);

        if (hallOfFame == null)
        {
            FranchiseHallOfFames.Add(new FranchiseHallOfFame(Id, franchiseId, year));
            return;
        }

        hallOfFame.Set(franchiseId, year);
    }    

    public void SetHallOfFame(int sportLeagueLevelId, int? inductionYear, decimal? votePercentage, int? ballotNumber)
    {
        var hallOfFame = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevelId == sportLeagueLevelId);

        if (hallOfFame == null)
        {
            HallOfFames.Add(new HallOfFame(inductionYear, Id, sportLeagueLevelId, votePercentage, ballotNumber));
            return;
        }

        hallOfFame.Set(inductionYear, sportLeagueLevelId, votePercentage, ballotNumber);
    }

    public void SetImage(string imageFileName)
    {
        ImageFileName = imageFileName;
    }

    public void SetInternationalHallOfFame(int id, int internationalHallOfFameTypeId, int? inductionYear)
    {
        if (id == 0)
        {
            InternationalHallOfFames.Add(new InternationalHallOfFame(Id, internationalHallOfFameTypeId, inductionYear));
            return;
        }

        var internationalhallOfFame = InternationalHallOfFames.SingleOrDefault(hof => hof.Id == id);

        internationalhallOfFame.Set(internationalHallOfFameTypeId, inductionYear);
    }

    public void SetLeader(int leaderId, int leaderTypeId, int year)
    {
        if (leaderId == 0)
        {
            Leaders.Add(new Leader(Id, leaderTypeId, year));
            return;
        }

        var leader = Leaders.Single(x => x.Id == leaderId);

        leader.Set(leaderTypeId, year);
    }

    public void SetNicknames(string[] nicknames)
    {
        if (nicknames.IsNullOrEmpty())
        {
            Nicknames = [];
            return;
        }

        string[] existingNicknames = Nicknames.Select(personNickname => personNickname.Nickname).ToArray();

        foreach (var nickname in nicknames.Where(nickname => !existingNicknames.Contains(nickname)))
        {
            Nicknames.Add(new PersonNickname(Id, nickname));
        }

        PersonNickname[] deletedNicknames 
            = Nicknames.Where(personNickname => !nicknames.Contains(personNickname.Nickname))
                       .ToArray();

        foreach (PersonNickname personNickname in deletedNicknames)
        {
            Nicknames.Remove(personNickname);
        }
    }

    public void SetOccupation(int occupationId, int occupationTypeId)
    {
        var occupation = occupationId > 0 
            ? Occupations.SingleOrDefault(occupation => occupation.OccupationId == occupationId) 
            : null;

        if (occupation == null)
        {
            Occupations.Add(new PersonOccupation(occupationId, occupationTypeId, Id));
            return;
        }

        occupation.Set(occupationId, occupationTypeId);
    }

    public void SetPosition(int positionId, PositionType positionType)
    {
        var position = Positions.SingleOrDefault(p => p.PositionId == positionId);

        if (position == null)
        {
            Positions.Add(new PersonPosition(Id, positionId, positionType));
            return;
        }

        position.Set(positionId, positionType);
    }

    public void SetRetiredNumber(int retiredNumberId, int franchiseId, int playerNumber)
    {
        if (retiredNumberId == 0)
        {
            RetiredNumbers.Add(new RetiredNumber(Id, franchiseId, playerNumber));
            return;
        }

        var retiredNumber = RetiredNumbers.Single(number => number.Id == retiredNumberId);

        retiredNumber.Set(franchiseId, playerNumber);
    }

    public void SetService(DateTime? debutDate, DateTime? freeAgentSigningDate, DateTime? lastAppearanceDate)
    {
        if (Service == null)
        {
            Service = new SportService(Id, debutDate, freeAgentSigningDate, lastAppearanceDate);
            return;
        }

        Service.Set(debutDate, freeAgentSigningDate, lastAppearanceDate);
    }

    public void SetSingleSeasonFranchiseRecord(int singleSeasonFranchiseRecordId, int franchiseId, string record, int recordTypeId, int year)
    {
        if (singleSeasonFranchiseRecordId == 0)
        {
            SingleSeasonFranchiseRecords.Add(new SingleSeasonFranchiseRecord(Id, recordTypeId, franchiseId, year, record));
            return;
        }

        var singleSeasonFranchiseRecord = SingleSeasonFranchiseRecords.Single(record => record.Id == singleSeasonFranchiseRecordId);

        singleSeasonFranchiseRecord.Set(Id, record, recordTypeId, year);
    }

    public void SetSingleSeasonRecord(int singleSeasonRecordId, int recordTypeId, int year, string record)
    {
        if (singleSeasonRecordId == 0)
        {
            SingleSeasonRecords.Add(new SingleSeasonRecord(Id, recordTypeId, year, record));
            return;
        }

        SingleSeasonRecords.Single(record => record.Id == singleSeasonRecordId).Set(recordTypeId, year, record);
    }

    public void SetSport(int sportId, bool isPrimary)
    {
        var sport = Sports.SingleOrDefault(sport => sport.SportId == sportId);

        if (sport == null)
        {
            Sports.Add(new PersonSport(Id, sportId, isPrimary));
            return;
        }

        sport.Set(sportId, isPrimary);
    }

    public void SetTeam(int id, int teamId, int? beginYear, int? endYear, int teamRoleTypeId)
    {
        var team = id > 0 
            ? Teams.SingleOrDefault(team => team.Id == id) 
            : Teams.SingleOrDefault(team => team.TeamId == teamId && team.BeginYear == beginYear && team.TeamRoleTypeId == teamRoleTypeId);

        if (team == null)
        {
            Teams.Add(new PersonTeam(Id, teamId, beginYear, endYear, teamRoleTypeId));
            return;
        }

        team.Set(teamId, beginYear, endYear, teamRoleTypeId);
    }        
}

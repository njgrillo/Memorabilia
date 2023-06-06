namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class ProfileModel : Model
{
    protected readonly Entity.Person Person;

    public ProfileModel() 
    {
        Person = new Entity.Person();
    }

    public ProfileModel(Entity.Person person)
    {
        Person = person;

        Accomplishments = Person.Accomplishments
                                .Select(accomplishment => new AccomplishmentProfileModel(accomplishment));
        Awards = Person.Awards
                       .Select(award => new AwardProfileModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName);
        Colleges = Person.Colleges
                         .Select(college => new CollegeProfileModel(college));
        HallOfFames = Person.HallOfFames
                            .Select(hof => new HallOfFameProfileModel(hof));

    }

    public virtual IEnumerable<AccomplishmentProfileModel> Accomplishments { get; set; } 
        = Enumerable.Empty<AccomplishmentProfileModel>();

    public virtual IEnumerable<AwardProfileModel> Awards { get; set; } 
        = Enumerable.Empty<AwardProfileModel>();

    public virtual IEnumerable<CollegeProfileModel> Colleges { get; set; } 
        = Enumerable.Empty<CollegeProfileModel>();

    public virtual AccomplishmentProfileModel[] DistinctAccomplishments 
        => Accomplishments.DistinctBy(accomplishment => accomplishment.AccomplishmentTypeId).ToArray();

    public virtual AwardProfileModel[] DistinctAwards 
        => Awards.DistinctBy(award => award.AwardTypeId).ToArray();

    public virtual IEnumerable<HallOfFameProfileModel> HallOfFames { get; set; } 
        = Enumerable.Empty<HallOfFameProfileModel>();

    public virtual bool HasAccomplishments 
        => Accomplishments?.Any() ?? false;

    public virtual bool HasAwards 
        => Awards?.Any() ?? false;

    public virtual bool HasHallOfFameData 
        => HallOfFames?.Any() ?? false;

    public string LifespanHeader
    {
        get
        {
            var header = $"Born {Person.BirthDate?.ToString("MM/dd/yyyy")}";

            return Person.DeathDate.HasValue ? $"{header} | Died {Person.DeathDate?.ToString("MM/dd/yyyy")}" : header;
        }
    }

    public virtual string NameHeader 
        => Person.ProfileName;

    public virtual string Nicknames 
        => Person.Nicknames.Any() 
        ? string.Join(" | ", Person.Nicknames.Select(personNickname => personNickname.Nickname)) 
        : string.Empty;

    public Entity.PersonOccupation[] Occupations 
        => Person.Occupations.ToArray();

    public string PersonImageFileName 
        => Person.ImageFileName;

    public Entity.PersonOccupation PrimaryOccupation 
        => Person.Occupations.First(occupation => occupation.OccupationTypeId == Constant.OccupationType.Primary.Id);
}

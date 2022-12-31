using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class ProfileViewModel : ViewModel
{
    protected readonly Person Person;

    public ProfileViewModel() 
    {
        Person = new Person();
    }

    public ProfileViewModel(Person person)
    {
        Person = person;

        Accomplishments = Person.Accomplishments
                                .Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment));
        Awards = Person.Awards
                       .Select(award => new AwardProfileViewModel(award))
                       .OrderBy(award => award.Year)
                       .ThenBy(award => award.AwardTypeName);
        Colleges = Person.Colleges
                         .Select(college => new CollegeProfileViewModel(college));
        HallOfFames = Person.HallOfFames
                            .Select(hof => new HallOfFameProfileViewModel(hof));

    }

    public virtual IEnumerable<AccomplishmentProfileViewModel> Accomplishments { get; set; } = Enumerable.Empty<AccomplishmentProfileViewModel>();

    public virtual IEnumerable<AwardProfileViewModel> Awards { get; set; } = Enumerable.Empty<AwardProfileViewModel>();

    public virtual IEnumerable<CollegeProfileViewModel> Colleges { get; set; } = Enumerable.Empty<CollegeProfileViewModel>();

    public virtual AccomplishmentProfileViewModel[] DistinctAccomplishments => Accomplishments.DistinctBy(accomplishment => accomplishment.AccomplishmentTypeId).ToArray();

    public virtual AwardProfileViewModel[] DistinctAwards => Awards.DistinctBy(award => award.AwardTypeId).ToArray();

    public virtual IEnumerable<HallOfFameProfileViewModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameProfileViewModel>();

    public virtual bool HasAccomplishments => Accomplishments?.Any() ?? false;

    public virtual bool HasAwards => Awards?.Any() ?? false;

    public virtual bool HasHallOfFameData => HallOfFames?.Any() ?? false;

    public string LifespanHeader
    {
        get
        {
            var header = $"Born {Person.BirthDate?.ToString("MM/dd/yyyy")}";

            return Person.DeathDate.HasValue ? $"{header} | Died {Person.DeathDate?.ToString("MM/dd/yyyy")}" : header;
        }
    }

    public virtual string NameHeader => Person.ProfileName;

    public virtual string Nicknames => Person.Nicknames.Any() ? string.Join(" | ", Person.Nicknames.Select(personNickname => personNickname.Nickname)) : string.Empty;

    public PersonOccupation[] Occupations => Person.Occupations.ToArray();

    public string PersonImageFileName => Person.ImageFileName;

    public PersonOccupation PrimaryOccupation => Person.Occupations.First(occupation => occupation.OccupationTypeId == Domain.Constants.OccupationType.Primary.Id);
}

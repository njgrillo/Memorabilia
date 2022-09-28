using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class ProfileViewModel : ViewModel
    {
        private readonly Person _person;

        public ProfileViewModel() 
        { 
            _person = new Person();
        }

        public ProfileViewModel(Person person)
        {
            _person = person;
        }

        public string LifespanHeader
        {
            get
            {
                var header = $"Born {_person.BirthDate?.ToString("MM/dd/yyyy")}";

                return _person.DeathDate.HasValue ? $"{header} | Died {_person.DeathDate?.ToString("MM/dd/yyyy")}" : header;
            }
        }

        public virtual string NameHeader => _person.ProfileName;

        public virtual string Nicknames => _person.Nicknames.Any() ? string.Join(" | ", _person.Nicknames.Select(personNickname => personNickname.Nickname)) : string.Empty;

        public PersonOccupation[] Occupations => _person.Occupations.ToArray();

        public string PersonImageData
        {
            get
            {
                return _person == null || _person.ImagePath.IsNullOrEmpty() 
                    ? "images/imagenotavailable.png"
                    : $"data:image/jpg;base64, {Convert.ToBase64String(File.ReadAllBytes(_person.ImagePath))}";
            }
        } 

        public PersonOccupation PrimaryOccupation => _person.Occupations.First(occupation => occupation.OccupationTypeId == Domain.Constants.OccupationType.Primary.Id);
    }
}

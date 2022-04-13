using Memorabilia.Application.Features.Tools.Profile.Common;
using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Tools.Profile.Baseball
{
    public class BaseballProfileViewModel : ProfileViewModel
    {
        private readonly Person _person;

        public BaseballProfileViewModel() { }

        public BaseballProfileViewModel(Person person) : base(person)
        {
            _person = person;

            HallOfFames = _person.HallOfFames.Select(hof => new HallOfFameProfileViewModel(hof));
            Service = new SportServiceProfileViewModel(_person.Service);
            Teams = _person.Teams.Select(team => new TeamProfileViewModel(team));
        }

        public IEnumerable<HallOfFameProfileViewModel> HallOfFames { get; set; }

        public string Debut => Service?.DebutDate.HasValue ?? false
            ? $"MLB Debut {Service.DebutDate.Value.ToString("MM/dd/yyyy")}"
            : string.Empty;

        public string LastAppearance => Service?.LastAppearanceDate.HasValue ?? false
            ? $"Last MLB Appearance {Service.LastAppearanceDate.Value.ToString("MM/dd/yyyy")}"
            : string.Empty;

        public override string NameHeader 
        { 
            get
            {
                var header = base.NameHeader;
                var hof = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball);

                if (hof == null)
                    return header;

                return $"{header} | HOF {hof.InductionYear}";
            }
        }

        public SportServiceProfileViewModel Service { get; set; }

        public IEnumerable<TeamProfileViewModel> Teams { get; set; }
    }
}

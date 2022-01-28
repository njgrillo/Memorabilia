using System;

namespace Memorabilia.Application.Features.Admin.Sport
{
    public class SportViewModel
    {
        private readonly Domain.Entities.Sport _sport;

        public SportViewModel() { }

        public SportViewModel(Domain.Entities.Sport sport)
        {
            _sport = sport;
        }

        public string AlternateName => _sport.AlternateName;

        public int Id => _sport.Id;

        public string ImagePath => _sport.ImagePath;

        public DateTime? LastModifiedDate => _sport.LastModifiedDate;

        public string Name => _sport.Name;
    }
}

using Memorabilia.Domain.Entities;
using System;

namespace Memorabilia.Application.Features.Tools.Profile.Common
{
    public class AccomplishmentProfileViewModel
    {
        private readonly PersonAccomplishment _accomplishment;

        public AccomplishmentProfileViewModel(PersonAccomplishment accomplishment)
        {
            _accomplishment = accomplishment;
        }

        public int AccomplishmentTypeId => _accomplishment.AccomplishmentTypeId;

        public string AccomplishmentTypeName => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId)?.Name;

        public DateTime? Date => _accomplishment.Date;  

        public string TimeFrame => Date?.ToString("MM/dd/yyyy") ?? Year?.ToString() ?? string.Empty;

        public int? Year => _accomplishment.Year;
    }
}

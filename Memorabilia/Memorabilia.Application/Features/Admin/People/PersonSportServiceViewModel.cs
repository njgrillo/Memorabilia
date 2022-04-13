using Memorabilia.Domain.Entities;
using System;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonSportServiceViewModel
    {
        private readonly SportService _sportService;

        public PersonSportServiceViewModel() { }

        public PersonSportServiceViewModel(SportService sportService)
        { 
            _sportService = sportService;
        }

        public DateTime? DebutDate => _sportService?.DebutDate;

        public DateTime? FreeAgentSigningDate => _sportService?.FreeAgentSigningDate;        

        public DateTime? LastAppearanceDate => _sportService?.LastAppearanceDate;

        public int PersonId => _sportService?.PersonId ?? 0;
    }
}

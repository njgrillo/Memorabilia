﻿using Framework.Extension;
using Memorabilia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Memorabilia.Application.Features.Admin.People
{
    public class PersonViewModel
    {
        private readonly Person _person;

        public PersonViewModel() { }

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public DateTime? BirthDate => _person.BirthDate;

        public DateTime? DeathDate => _person.DeathDate;

        public string DisplayName => _person.DisplayName;

        public string FirstName => _person.FirstName;    
        
        public string FormattedBirthDate => _person.BirthDate?.ToString("MM-dd-yyyy") ?? string.Empty;

        public string FormattedDeathDate => _person.DeathDate?.ToString("MM-dd-yyyy") ?? string.Empty;

        public int Id => _person.Id;

        public string ImagePath => _person.ImagePath.IsNullOrEmpty()
            ? "wwwroot/images/imagenotavailable.png"
            : _person.ImagePath;

        public DateTime? LastModifiedDate => _person.LastModifiedDate;

        public string LastName => _person.LastName; 

        public string LegalName => _person.LegalName;

        public string MiddleName => _person.MiddleName;

        public string Nickname => _person.Nickname;

        public IEnumerable<PersonNickname> Nicknames => _person.Nicknames;

        public IEnumerable<PersonOccupation> Occupations => _person.Occupations;

        public string PersonImagePath => $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(ImagePath))}";

        public string ProfileName => _person.ProfileName;   

        public string Suffix => _person.Suffix;

        public IEnumerable<PersonTeam> Teams => _person.Teams;
    }
}

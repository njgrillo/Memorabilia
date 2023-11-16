namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePerson
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            if (command.IsNew)
            {
                person = new Entity.Person(command.FirstName, 
                                           command.LastName, 
                                           command.MiddleName,
                                           command.Suffix, 
                                           command.Nickname, 
                                           command.LegalName,
                                           command.DisplayName,
                                           command.ProfileName,
                                           command.BirthDate, 
                                           command.DeathDate,
                                           command.Nicknames);

                await personRepository.Add(person);

                command.Id = person.Id;

                return;
            }

            person = await personRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await personRepository.Delete(person);

                return;
            }

            person.Set(command.FirstName, 
                       command.LastName,
                       command.MiddleName,
                       command.Suffix,
                       command.Nickname,
                       command.LegalName,
                       command.DisplayName,
                       command.ProfileName,
                       command.BirthDate, 
                       command.DeathDate,
                       command.Nicknames);

            await personRepository.Update(person);
        }
    }

    public class Command(PersonEditModel editModel) 
        : DomainCommand, ICommand
    {
        public DateTime? BirthDate 
            => editModel.BirthDate;

        public DateTime? DeathDate 
            => editModel.DeathDate;

        public string DisplayName
        {
            get
            {
                if (!editModel.DisplayName.IsNullOrEmpty())
                    return editModel.DisplayName;

                return $"{editModel.LastName}"
                    + (!editModel.Suffix.IsNullOrEmpty() ? $" {editModel.Suffix}, " : ", ")
                    + (!editModel.Nickname.IsNullOrEmpty() ? $" {editModel.Nickname}" : string.Empty)
                    + (!editModel.FirstName.IsNullOrEmpty() 
                        ? (!editModel.Nickname.IsNullOrEmpty() 
                            ? $" ({editModel.FirstName})" 
                            : editModel.FirstName) 
                        : string.Empty);
            }
        }

        public string FirstName 
            => editModel.FirstName;

        public int Id { get; set; } 
            = editModel.Id;

        public bool IsDeleted 
            => editModel.IsDeleted;

        public bool IsNew 
            => editModel.IsNew;

        public string LastName 
            => editModel.LastName;

        public string LegalName 
            => editModel.LegalName;

        public string MiddleName 
            => editModel.MiddleName;

        public string Nickname 
            => editModel.Nickname;

        public string[] Nicknames 
            => editModel.Nicknames
                         .Select(nickname => nickname.Nickname)
                         .ToArray();

        public string  ProfileName
        {
            get
            {
                if (!editModel.ProfileName.IsNullOrEmpty())
                    return editModel.ProfileName;

                return $"{(!editModel.Nickname.IsNullOrEmpty() ? editModel.Nickname : editModel.FirstName)}"
                    + $" {editModel.LastName}"
                    + (!editModel.Suffix.IsNullOrEmpty() ? $" {editModel.Suffix}" : string.Empty);
            }
        }

        public string Suffix 
            => editModel.Suffix;
    }
}

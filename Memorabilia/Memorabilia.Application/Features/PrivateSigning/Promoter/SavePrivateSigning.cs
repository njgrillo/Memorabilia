namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public class SavePrivateSigning
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IPrivateSigningRepository _privateSigningRepository;

        public Handler(IPrivateSigningRepository privateSigningRepository)
        {
            _privateSigningRepository = privateSigningRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.PrivateSigning privateSigning;

            if (command.IsNew)
            {
                privateSigning
                    = new Entity.PrivateSigning(command.CreatedDate,
                                                command.CreatedByUserId,
                                                command.Note,
                                                command.SelfAddressedStampedEnvelopeAccepted,
                                                command.SigningDate.Value,
                                                command.SubmissionDeadlineDate.Value);

                SetAuthenticationCompanies(command, privateSigning);
                SetPerson(command, privateSigning);
                //SetProjectMemorabiliaTeams(project, command);

                await _privateSigningRepository.Add(privateSigning);

                command.Id = privateSigning.Id;

                return;
            }

            privateSigning = await _privateSigningRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await _privateSigningRepository.Delete(privateSigning);

                return;
            }

            privateSigning.Set(command.Note,
                               command.SelfAddressedStampedEnvelopeAccepted,
                               command.SigningDate.Value,
                               command.SubmissionDeadlineDate.Value);

            SetAuthenticationCompanies(command, privateSigning);
            SetPerson(command, privateSigning);
            //SetProjectMemorabiliaTeams(project, command);
            //DeleteProjectPeople(project, command);
            //DeleteProjectMemorabiliaTeams(project, command);

            await _privateSigningRepository.Update(privateSigning);
        }

        private static void SetAuthenticationCompanies(Command command, Entity.PrivateSigning privateSigning)
        {
            foreach (PrivateSigningAuthenticationCompanyEditModel authenticationCompany in command.AuthenticationCompanies.Where(item => !item.IsDeleted))
            {
                privateSigning.SetAuthenticationCompany(authenticationCompany.Id,
                                                        authenticationCompany.AuthenticationCompany.Id,
                                                        authenticationCompany.Cost.Value);
            }
        }

        private static void SetPerson(Command command, Entity.PrivateSigning privateSigning)
        {
            foreach (PrivateSigningPersonEditModel privateSigningPerson in command.People.Where(person => !person.IsDeleted))
            {
                privateSigning.SetPerson(privateSigningPerson.AllowInscriptions,
                                         privateSigningPerson.InscriptionCost,
                                         privateSigningPerson.Id,
                                         privateSigningPerson.Note,
                                         privateSigningPerson.Person.Id,
                                         privateSigningPerson.PromoterImageFileName,
                                         privateSigningPerson.SpotsAvailable,
                                         privateSigningPerson.SpotsConfirmed);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PrivateSigningEditModel _editModel;

        public Command(PrivateSigningEditModel editModel)
        {
            _editModel = editModel;

            Id = _editModel.Id;
        }

        public PrivateSigningAuthenticationCompanyEditModel[] AuthenticationCompanies
            => _editModel.AuthenticationCompanies.Any()
                ? _editModel.AuthenticationCompanies.ToArray()
                : Array.Empty<PrivateSigningAuthenticationCompanyEditModel>();

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedByUserId
            => _editModel.CreatedByUserId;

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public string Note
            => _editModel.Note;

        public PrivateSigningPersonEditModel[] People 
            => _editModel.People.Any()
                ? _editModel.People.ToArray()
                : Array.Empty<PrivateSigningPersonEditModel>();

        public bool SelfAddressedStampedEnvelopeAccepted
            => _editModel.SelfAddressedStampedEnvelopeAccepted;

        public DateTime? SigningDate
            => _editModel.SigningDate;

        public DateTime? SubmissionDeadlineDate
            => _editModel.SubmissionDeadlineDate;
    }
}

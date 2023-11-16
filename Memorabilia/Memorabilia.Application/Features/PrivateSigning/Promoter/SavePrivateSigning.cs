namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public class SavePrivateSigning
{
    public class Handler(IPrivateSigningRepository privateSigningRepository) 
        : CommandHandler<Command>
    {
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
                                                command.SubmissionDeadlineDate.Value,
                                                command.PromoterImageFileName);

                SetAuthenticationCompanies(command, privateSigning);
                SetPerson(command, privateSigning);
                SetProvidedItems(command, privateSigning);

                await privateSigningRepository.Add(privateSigning);

                command.Id = privateSigning.Id;

                return;
            }

            privateSigning = await privateSigningRepository.Get(command.Id);

            if (command.IsDeleted)
            {
                await privateSigningRepository.Delete(privateSigning);

                return;
            }

            privateSigning.Set(command.Note,
                               command.SelfAddressedStampedEnvelopeAccepted,
                               command.SigningDate.Value,
                               command.SubmissionDeadlineDate.Value,
                               command.PromoterImageFileName);

            SetAuthenticationCompanies(command, privateSigning);
            SetPerson(command, privateSigning);
            SetProvidedItems(command, privateSigning);
            //TODO
            //DeleteProjectPeople(project, command);
            //DeleteProjectMemorabiliaTeams(project, command);

            await privateSigningRepository.Update(privateSigning);
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

        private static void SetCustomPricing(Command command, Entity.PrivateSigningPerson privateSigningPerson)
        {
            foreach (PrivateSigningPersonDetailEditModel privateSigningPersonDetail in command.CustomPricing.Where(price => !price.IsDeleted && price.Person.Id == privateSigningPerson.PersonId))
            {
                privateSigningPerson.SetCustomPrice(privateSigningPersonDetail.Cost ?? 0,
                                                    privateSigningPersonDetail.Note,
                                                    privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetail.Id,
                                                    privateSigningPersonDetail.Id,
                                                    privateSigningPerson.Id,
                                                    privateSigningPersonDetail.ShippingCost);
            }
        }

        private static void SetExcludedItems(Command command, Entity.PrivateSigningPerson privateSigningPerson)
        {
            foreach (PrivateSigningPersonExcludeItemTypeEditModel privateSigningPersonExcludeItemType in command.ExcludedItems.Where(item => !item.IsDeleted && item.Person.Id == privateSigningPerson.PersonId))
            {
                privateSigningPerson.SetExcludedItem(privateSigningPersonExcludeItemType.Id,
                                                     privateSigningPersonExcludeItemType.ItemType.Id,
                                                     privateSigningPersonExcludeItemType.Note,
                                                     privateSigningPersonExcludeItemType.PrivateSigningPersonId);
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

                Entity.PrivateSigningPerson person
                    = privateSigning.People.Single(person => person.PersonId == privateSigningPerson.Person.Id);

                SetCustomPricing(command, person);
                SetExcludedItems(command, person);
                SetPricing(command, person);
            }
        }

        private static void SetPricing(Command command, Entity.PrivateSigningPerson privateSigningPerson)
        {
            foreach (PrivateSigningPersonDetailEditModel privateSigningPersonDetail in command.Pricing.Where(price => !price.IsDeleted && price.Person.Id == privateSigningPerson.PersonId))
            {
                privateSigningPerson.SetPrice(privateSigningPersonDetail.Cost ?? 0,
                                              privateSigningPersonDetail.Note,
                                              privateSigningPersonDetail.PrivateSigningItemGroup.Id,
                                              privateSigningPersonDetail.Id, 
                                              privateSigningPerson.Id,
                                              privateSigningPersonDetail.ShippingCost);
            }
        }

        private static void SetProvidedItems(Command command, Entity.PrivateSigning privateSigning)
        {
            foreach (PromoterProvidedItemEditModel providedItem in command.ProvidedItems.Where(item => !item.IsDeleted))
            {
                privateSigning.SetProvidedItem(providedItem.Id,
                                               providedItem.Cost.Value,
                                               providedItem.ItemType.Id,
                                               providedItem.PromoterId,
                                               providedItem.ShippingCost);
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
            => _editModel.AuthenticationCompanies.Count != 0
                ? _editModel.AuthenticationCompanies.ToArray()
                : [];

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int CreatedByUserId
            => _editModel.CreatedByUserId;

        public PrivateSigningPersonDetailEditModel[] CustomPricing
            => _editModel.People.Count != 0
                ? _editModel.People.SelectMany(person => person.Pricing.Where(price => (price.PrivateSigningItemGroup?.Id ?? 0) == 0)).ToArray()
                : [];

        public PrivateSigningPersonExcludeItemTypeEditModel[] ExcludedItems
            => People.SelectMany(person => person.ExcludedItems).Any()
                ? People.SelectMany(person => person.ExcludedItems).ToArray()
                : [];

        public int Id { get; set; }

        public bool IsDeleted
            => _editModel.IsDeleted;

        public bool IsNew
            => _editModel.IsNew;

        public string Note
            => _editModel.Note;

        public PrivateSigningPersonEditModel[] People 
            => _editModel.People.Count != 0
                ? _editModel.People.ToArray()
                : [];

        public PrivateSigningPersonDetailEditModel[] Pricing
            => _editModel.People.Count != 0
                ? _editModel.People.SelectMany(person => person.Pricing.Where(price => (price.PrivateSigningItemGroup?.Id ?? 0) > 0)).ToArray()
                : [];

        public string PromoterImageFileName
            => _editModel.PromoterImageFileName;

        public PromoterProvidedItemEditModel[] ProvidedItems
            => _editModel.ProvidedItems.Count != 0
                ? _editModel.ProvidedItems.ToArray()
                : [];

        public bool SelfAddressedStampedEnvelopeAccepted
            => _editModel.SelfAddressedStampedEnvelopeAccepted;

        public DateTime? SigningDate
            => _editModel.SigningDate;

        public DateTime? SubmissionDeadlineDate
            => _editModel.SubmissionDeadlineDate;
    }
}

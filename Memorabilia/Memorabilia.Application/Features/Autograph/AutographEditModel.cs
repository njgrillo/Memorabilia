namespace Memorabilia.Application.Features.Autograph;

public class AutographEditModel : EditModel
{
    public AutographEditModel() { }

    public AutographEditModel(AutographModel viewModel)
    {
        AcquiredDate = viewModel.Acquisition?.AcquiredDate;
        AcquiredWithAutograph = viewModel.AcquiredWithAutograph;
        AcquisitionTypeId = viewModel.Acquisition?.AcquisitionTypeId ?? 0;
        ColorId = viewModel.ColorId;
        ConditionId = viewModel.ConditionId;
        Cost = viewModel.Acquisition?.Cost;
        CreateDate = viewModel.CreateDate;
        Denominator = viewModel.Denominator;
        EstimatedValue = viewModel.EstimatedValue;
        FullName = viewModel.FullName ?? false;
        Grade = viewModel.Grade;
        Id = viewModel.Id;
        ItemType = viewModel.ItemType;
        LastModifiedDate = viewModel.LastModifiedDate;
        MemorabiliaId = viewModel.MemorabiliaId;
        MemorabiliaImageNames = viewModel.MemorabiliaImageNames;
        Note = viewModel.Note;
        Numerator = viewModel.Numerator;    
        Person = new SavePersonViewModel(new PersonViewModel(viewModel.Person));
        PersonalizationText = viewModel.Personalization?.Text;
        PurchaseTypeId = viewModel.Acquisition?.PurchaseTypeId ?? 0;
        ReceivedDate = viewModel.ReceivedDate;
        SentDate = viewModel.SentDate;
        UserId = viewModel.UserId;
        WritingInstrumentId = viewModel.WritingInstrumentId;
    }

    public AutographEditModel(MemorabiliaItemModel viewModel)
    {
        AcquiredWithAutograph = viewModel.Acquisition?.AcquiredWithAutograph ?? false;
        MemorabiliaAcquiredDate = viewModel.Acquisition.AcquiredDate;
        MemorabiliaAcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
        MemorabiliaCost = viewModel.Acquisition.Cost;
        MemorabiliaEstimatedValue = viewModel.EstimatedValue;
        MemorabiliaId = viewModel.Id;
        MemorabiliaImageNames = viewModel.Images.Select(image => image.FileName).ToArray();
        MemorabiliaPurchaseTypeId = viewModel.Acquisition.PurchaseTypeId;
        ItemType = Constant.ItemType.Find(viewModel.ItemTypeId);
        UserFirstName = viewModel.UserFirstName;
        UserId = viewModel.UserId;

        Entity.Person person = viewModel.People.FirstOrDefault()?.Person;

        MemorabiliaPerson = person != null ? new PersonViewModel(person) : new PersonViewModel();
    }

    public DateTime? AcquiredDate { get; set; }

    public bool AcquiredWithAutograph { get; set; }

    public Constant.AcquisitionType AcquisitionType
        => Constant.AcquisitionType.Find(AcquisitionTypeId);

    public int AcquisitionTypeId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Autograph;

    public override string BackNavigationPath 
        => $"Memorabilia/Image/{Constant.EditModeType.Update.Name}/{MemorabiliaId}";

    public bool CanHaveCost 
        => AcquisitionType?.CanHaveCost() ?? false;

    public bool CanHavePlaceOfPurchase 
        => AcquisitionType == Constant.AcquisitionType.Purchase;

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public bool CanImportPerson 
        => MemorabiliaPerson?.Id > 0;

    public int ColorId { get; set; }

    public int ConditionId { get; set; } 
        = Constant.Condition.Pristine.Id;

    public decimal? Cost { get; set; }

    public DateTime CreateDate { get; set; }

    public int? Denominator { get; set; }

    public bool DisplayAcquisitionDetails 
        => !AcquiredWithAutograph;

    public bool DisplayThroughTheMailDetails 
        => AcquisitionType == Constant.AcquisitionType.ThroughTheMail;

    public decimal? EstimatedValue { get; set; }

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public bool FullName { get; set; }

    public int? Grade { get; set; }

    public bool HasMemorabiliaImages 
        => MemorabiliaImageNames.Any();

    public string ImageFileName 
        => Constant.ImageFileName.Autographs;

    private bool? _isNumbered;
    public bool IsNumbered
    {
        get
        {
            _isNumbered ??= Numerator.HasValue || Denominator.HasValue;

            return _isNumbered ?? false;
        }
        set
        {
            _isNumbered = value;

            if (!_isNumbered ?? false)
            {
                Denominator = null;
                Numerator = null;
            }
        }
    }

    private bool? _isPersonalized;
    public bool IsPersonalized
    {
        get
        {
            _isPersonalized ??= !PersonalizationText.IsNullOrEmpty();

            return _isPersonalized ?? false;
        }
        set
        {
            _isPersonalized = value;

            if (!_isPersonalized ?? false)
                PersonalizationText = null;
            else
            {
                if (PersonalizationText.IsNullOrEmpty())
                    PersonalizationText = $"To {UserFirstName}";
            } 
        }
    }

    public Constant.ItemType ItemType { get; set; }

    public string ItemTypeName => ItemType?.Name;

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? MemorabiliaAcquiredDate { get; set; }

    public int MemorabiliaAcquisitionTypeId { get; set; }

    public decimal? MemorabiliaCost { get; set; }

    public decimal? MemorabiliaEstimatedValue { get; set; }

    public int MemorabiliaId { get; set; }

    public string[] MemorabiliaImageNames { get; }

    public PersonViewModel MemorabiliaPerson { get; set; }

    public int? MemorabiliaPurchaseTypeId { get; set; }

    public string Note { get; set; }

    public int? Numerator { get; set; }

    public override string PageTitle 
        => $"{(Id > 0 ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} Autograph";

    public SavePersonViewModel Person { get; set; } = new();

    public string PersonalizationText { get; set; }

    public int PurchaseTypeId { get; set; }

    public DateTime? ReceivedDate { get; set; }

    public DateTime? SentDate { get; set; }

    public string UserFirstName { get; set; }

    public int UserId { get; }

    public int WritingInstrumentId { get; set; }
}

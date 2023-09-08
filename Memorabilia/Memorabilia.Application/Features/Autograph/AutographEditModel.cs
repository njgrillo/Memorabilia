namespace Memorabilia.Application.Features.Autograph;

public class AutographEditModel : EditModel
{
    public AutographEditModel() { }

    public AutographEditModel(AutographModel model)
    {
        AcquiredDate = model.Acquisition?.AcquiredDate;
        AcquiredWithAutograph = model.AcquiredWithAutograph;
        AcquisitionTypeId = model.Acquisition?.AcquisitionTypeId ?? 0;
        ColorId = model.ColorId;
        ConditionId = model.ConditionId;
        Cost = model.Acquisition?.Cost;
        CreateDate = model.CreateDate;
        Denominator = model.Denominator;
        EstimatedValue = model.EstimatedValue;
        FullName = model.FullName ?? false;
        Grade = model.Grade;
        Id = model.Id;
        ItemType = model.ItemType;
        LastModifiedDate = model.LastModifiedDate;
        MemorabiliaId = model.MemorabiliaId;
        MemorabiliaImageNames = model.MemorabiliaImageNames;
        Note = model.Note;
        Numerator = model.Numerator;
        Person = model.Person.ToEditModel();
        PersonalizationText = model.Personalization?.Text;
        PurchaseTypeId = model.Acquisition?.PurchaseTypeId ?? 0;
        ThroughTheMailId = model.ThroughTheMailId ?? 0;
        UserId = model.UserId;
        WritingInstrumentId = model.WritingInstrumentId;
    }

    public AutographEditModel(MemorabiliaModel model)
    {
        AcquiredWithAutograph = model.Acquisition?.AcquiredWithAutograph ?? false;
        MemorabiliaAcquiredDate = model.Acquisition.AcquiredDate;
        MemorabiliaAcquisitionTypeId = model.Acquisition.AcquisitionTypeId;
        MemorabiliaCost = model.Acquisition.Cost;
        MemorabiliaEstimatedValue = model.EstimatedValue;
        MemorabiliaId = model.Id;

        MemorabiliaImageNames = model.Images
                                     .Select(image => image.FileName)
                                     .ToArray() ?? Array.Empty<string>();

        MemorabiliaPurchaseTypeId = model.Acquisition.PurchaseTypeId;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        UserFirstName = model.UserFirstName;
        UserId = model.UserId;

        Entity.Person person = model.People.FirstOrDefault()?.Person;

        MemorabiliaPerson = person != null ? new PersonModel(person) : new PersonModel();
    }

    public DateTime? AcquiredDate { get; set; }

    public bool AcquiredWithAutograph { get; set; }

    public Constant.AcquisitionType AcquisitionType
        => Constant.AcquisitionType.Find(AcquisitionTypeId);

    public int AcquisitionTypeId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Autograph;

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

    public decimal? EstimatedValue { get; set; }

    public override string ExitNavigationPath 
        => "MyStuff/Memorabilia/View";

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

    public override string ItemTitle 
        => "Autograph";

    public Constant.ItemType ItemType { get; set; }

    public string ItemTypeName 
        => ItemType?.Name;

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? MemorabiliaAcquiredDate { get; set; }

    public int MemorabiliaAcquisitionTypeId { get; set; }

    public decimal? MemorabiliaCost { get; set; }

    public decimal? MemorabiliaEstimatedValue { get; set; }

    public int MemorabiliaId { get; set; }

    public string[] MemorabiliaImageNames { get; }
        = Array.Empty<string>();

    public PersonModel MemorabiliaPerson { get; set; }

    public int? MemorabiliaPurchaseTypeId { get; set; }

    public string Note { get; set; }

    public int? Numerator { get; set; }

    public override string PageTitle 
        => $"{Id.ToEditModeTypeName()} Autograph";

    public PersonEditModel Person { get; set; } 
        = new();

    public string PersonalizationText { get; set; }

    public int PurchaseTypeId { get; set; }

    public int ThroughTheMailId { get; private set; }

    public string UserFirstName { get; set; }

    public int UserId { get; }

    public int WritingInstrumentId { get; set; }
}

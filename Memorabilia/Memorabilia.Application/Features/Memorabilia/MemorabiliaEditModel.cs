namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaEditModel : EditModel
{
    public MemorabiliaEditModel() { }

    public MemorabiliaEditModel(MemorabiliaModel model)
    {
        AcquiredDate = model.Acquisition.AcquiredDate;
        AcquiredWithAutograph = model.Acquisition.AcquiredWithAutograph ?? false;
        AcquisitionTypeId = model.Acquisition.AcquisitionTypeId;
        Collections = model.Collections;
        ConditionId = model.ConditionId ?? 0;
        Cost = model.Acquisition.Cost;
        CreateDate = model.CreateDate;
        Denominator = model.Denominator;
        EstimatedValue = model.EstimatedValue;
        ForTrade = model.ForTrade;
        Framed = model.Framed;
        Id = model.Id;
        ItemType = Constant.ItemType.Find(model.ItemTypeId);
        LastModifiedDate = model.LastModifiedDate;
        Note = model.Note;
        Numerator = model.Numerator;
        PrivacyTypeId = model.PrivacyTypeId;            
        PurchaseTypeId = model.PurchaseTypeId ?? 0;
        ThroughTheMailIds = model.ThroughTheMailIds;
        UserId = model.UserId;
    }

    public DateTime? AcquiredDate { get; set; }

    public bool AcquiredWithAutograph { get; set; }

    public Constant.AcquisitionType AcquisitionType
        => Constant.AcquisitionType.Find(AcquisitionTypeId);

    public int AcquisitionTypeId { get; set; } 
        = Constant.AcquisitionType.Purchase.Id;

    public bool CanEditItemType 
        => Id == 0;

    public bool CanHaveCost 
        => AcquisitionType?.CanHaveCost() ?? false;

    public List<Entity.Collection> Collections { get; set; } 
        = new();

    public int ConditionId { get; set; } 
        = Constant.Condition.Pristine.Id;

    public decimal? Cost { get; set; }

    public DateTime CreateDate { get; set; }

    public int? Denominator { get; set; }

    public decimal? EstimatedValue { get; set; }

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public bool ForTrade { get; set; }

    public bool Framed { get; set; }

    public string ImageFileName 
        => $"{(!ItemTypeName.IsNullOrEmpty() ? $"{ItemTypeName.Replace(" ", "")}.jpg" : "itemtypes.jpg")}";

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

    public override string ItemTitle
        => ItemTypeName;

    public Constant.ItemType ItemType { get; set; }

    public string ItemTypeName 
        => ItemType?.Name;

    public DateTime? LastModifiedDate { get; set; }

    public Constant.MemorabiliaItemStep MemorabiliaItemStep
        => Constant.MemorabiliaItemStep.Item;

    public string Note { get; set; }

    public int? Numerator { get; set; }

    public override string PageTitle 
        => $"{Id.ToEditModeTypeName()} {(ItemType?.Id > 0 ? ItemTypeName : "Memorabilia")}";

    public int PrivacyTypeId { get; set; } 
        = Constant.PrivacyType.Public.Id;

    public int PurchaseTypeId { get; set; }

    public int[] ThroughTheMailIds { get; private set; }
        = Array.Empty<int>();

    public int UserId { get; set; }
}

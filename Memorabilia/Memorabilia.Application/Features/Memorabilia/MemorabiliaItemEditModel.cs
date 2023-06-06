namespace Memorabilia.Application.Features.Memorabilia;

public class MemorabiliaItemEditModel : EditModel
{
    public MemorabiliaItemEditModel() { }

    public MemorabiliaItemEditModel(MemorabiliaItemModel viewModel)
    {
        AcquiredDate = viewModel.Acquisition.AcquiredDate;
        AcquiredWithAutograph = viewModel.Acquisition.AcquiredWithAutograph ?? false;
        AcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
        Collections = viewModel.Collections;
        ConditionId = viewModel.ConditionId ?? 0;
        Cost = viewModel.Acquisition.Cost;
        CreateDate = viewModel.CreateDate;
        Denominator = viewModel.Denominator;
        EstimatedValue = viewModel.EstimatedValue;
        ForTrade = viewModel.ForTrade;
        Framed = viewModel.Framed;
        Id = viewModel.Id;
        ItemType = Constant.ItemType.Find(viewModel.ItemTypeId);
        LastModifiedDate = viewModel.LastModifiedDate;
        Note = viewModel.Note;
        Numerator = viewModel.Numerator;
        PrivacyTypeId = viewModel.PrivacyTypeId;            
        PurchaseTypeId = viewModel.PurchaseTypeId ?? 0;            
        UserId = viewModel.UserId;
    }

    public DateTime? AcquiredDate { get; set; }

    public bool AcquiredWithAutograph { get; set; }

    public Constant.AcquisitionType AcquisitionType
        => Constant.AcquisitionType.Find(AcquisitionTypeId);

    public int AcquisitionTypeId { get; set; } 
        = Constant.AcquisitionType.Purchase.Id;

    public bool CanEditItemType => Id == 0;

    public bool CanHaveCost 
        => AcquisitionType?.CanHaveCost() ?? false;

    public List<Entity.Collection> Collections { get; set; } = new();

    public int ConditionId { get; set; } 
        = Constant.Condition.Pristine.Id;

    public decimal? Cost { get; set; }

    public DateTime CreateDate { get; set; }

    public int? Denominator { get; set; }

    public decimal? EstimatedValue { get; set; }

    public override string ExitNavigationPath => "Memorabilia/View";

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

    public Constant.ItemType ItemType { get; set; }

    public string ItemTypeName => ItemType?.Name;

    public DateTime? LastModifiedDate { get; set; }

    public Constant.MemorabiliaItemStep MemorabiliaItemStep => Constant.MemorabiliaItemStep.Item;

    public string Note { get; set; }

    public int? Numerator { get; set; }

    public override string PageTitle 
        => $"{(Id > 0 ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} {(ItemType?.Id > 0 ? ItemTypeName : "Memorabilia")}";

    public int PrivacyTypeId { get; set; } 
        = Constant.PrivacyType.Public.Id;

    public int PurchaseTypeId { get; set; }

    public int UserId { get; set; }
}

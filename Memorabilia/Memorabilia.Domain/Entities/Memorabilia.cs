namespace Memorabilia.Domain.Entities;

public partial class Memorabilia : Entity
{  
    public virtual Acquisition Acquisition 
        => MemorabiliaAcquisition.Acquisition;

    public virtual List<Autograph> Autographs { get; private set; } 
        = new ();

    public virtual MemorabiliaBammer Bammer { get; private set; }

    public virtual MemorabiliaBaseball Baseball { get; private set; }

    public virtual MemorabiliaBasketball Basketball { get; private set; }

    public virtual MemorabiliaBat Bat { get; private set; }

    public virtual MemorabiliaBobblehead Bobblehead { get; private set; }

    public virtual MemorabiliaBook Book { get; private set; }

    public virtual MemorabiliaBrand Brand { get; private set; }

    public virtual MemorabiliaCard Card { get; private set; }

    public virtual MemorabiliaCereal Cereal { get; private set; }

    public virtual List<CollectionMemorabilia> CollectionMemorabilias { get; private set; } 
        = new();

    public virtual MemorabiliaCommissioner Commissioner { get; private set; }

    public Constants.Condition Condition 
        => Constants.Condition.Find(ConditionId ?? 0);

    public int? ConditionId { get; private set; }

    public DateTime CreateDate { get; private set; }

    public int? Denominator { get; private set; }

    public virtual MemorabiliaFigure Figure { get; private set; }

    public virtual MemorabiliaFirstDayCover FirstDayCover { get; private set; }

    public virtual MemorabiliaFootball Football { get; private set; }

    public virtual MemorabiliaForSale ForSale { get; private set; }

    public bool ForTrade { get; private set; }

    public bool Framed { get; private set; }

    public decimal? EstimatedValue { get; private set; }

    public virtual MemorabiliaGame Game { get; private set; }

    public virtual MemorabiliaGlove Glove { get; private set; }

    public virtual MemorabiliaHelmet Helmet { get; private set; }

    public virtual List<MemorabiliaImage> Images { get; private set; } 
        = new ();

    public Constant.ItemType ItemType 
        => Constant.ItemType.Find(ItemTypeId);

    public int ItemTypeId { get; private set; }

    public virtual MemorabiliaJersey Jersey { get; private set; }

    public virtual MemorabiliaJerseyNumber JerseyNumber { get; private set; }

    public DateTime? LastModifiedDate { get; private set; }

    public virtual MemorabiliaLevelType LevelType { get; private set; }

    public virtual MemorabiliaMagazine Magazine { get; private set; }

    public virtual MemorabiliaAcquisition MemorabiliaAcquisition { get; private set; }

    public string Note { get; private set; }

    public int? Numerator { get; private set; }

    public virtual List<MemorabiliaPerson> People { get; private set; } 
        = new ();

    public virtual MemorabiliaPicture Picture { get; private set; }

    public int PrivacyTypeId { get; private set; }

    public virtual MemorabiliaTransactionSale Sale { get; private set; }

    public virtual MemorabiliaSize Size { get; private set; }

    public virtual List<MemorabiliaSport> Sports { get; private set; } 
        = new ();

    public virtual List<MemorabiliaTeam> Teams { get; private set; } 
        = new ();

    public virtual List<ThroughTheMailMemorabilia> ThroughTheMailMemorabilias { get; private set; } 
        = new ();

    public virtual MemorabiliaTransactionTrade Trade { get; private set; }

    public virtual User User { get; set; }

    public int UserId { get; private set; }       
}

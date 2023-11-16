namespace Memorabilia.Application.Features.Transaction;

public class MemorabiliaTransactionsModel : Model
{
    public MemorabiliaTransactionsModel() { }

    public MemorabiliaTransactionsModel(Entity.MemorabiliaTransaction[] memorabiliaTransactions,
                                        PageInfoResult pageInfo = null)
    {
        Items = memorabiliaTransactions.Select(item => new MemorabiliaTransactionModel(item))
                                       .ToList();

        PageInfo = pageInfo;
    }

    public string AddRoute
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath
        => "Home";

    public List<MemorabiliaTransactionModel> Items { get; set; }
        = [];

    public override string ItemTitle
        => "Sales";

    public override string PageTitle
        => "Sales";

    public override string RoutePrefix
        => "Sales";
}

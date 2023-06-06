namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public abstract class GalleryRule
{
    public virtual string AcquisitionTypeText(Entity.Memorabilia memorabilia)
    {
        return $"Acquired:{Constant.AcquisitionType.Find(memorabilia.MemorabiliaAcquisition?.Acquisition?.AcquisitionTypeId ?? 0)?.Name ?? string.Empty}";
    }

    public virtual string AutographTitleText(Entity.Memorabilia memorabilia)
    {
        return memorabilia.Autographs.Count switch
        {
            0 => string.Empty,
            1 => "Autographed",
            2 => "Dual Signed",
            > 2 => "Multi Signed",
            _ => string.Empty,
        };
    }

    public virtual string ConditionText(Entity.Memorabilia memorabilia)
    {
        return $"Condition: {memorabilia.Condition?.Name ?? string.Empty}";
    }

    public virtual string CostText(Entity.Memorabilia memorabilia)
    {
        var cost = (memorabilia.MemorabiliaAcquisition?.Acquisition?.Cost ?? 0) 
            + memorabilia.Autographs?.Sum(autograph => autograph?.Acquisition?.Cost ?? 0);

        return $"Cost: {cost?.ToString("C") ?? string.Empty}";
    }

    public virtual string EstimatedValueText(Entity.Memorabilia memorabilia)
    {
        var value = (memorabilia.EstimatedValue ?? 0) + memorabilia.Autographs?.Sum(autograph => autograph?.EstimatedValue ?? 0);

        return $"Value: {value?.ToString("C") ?? string.Empty}";
    }

    public virtual string GetDescription(Entity.Memorabilia memorabilia)
    {
        return $"{ConditionText(memorabilia)}, {AcquisitionTypeText(memorabilia)}";
    }

    public virtual string GetSubtitle(Entity.Memorabilia memorabilia)
    {
        return $"{CostText(memorabilia)}, {EstimatedValueText(memorabilia)}, {ProfitLossText(memorabilia)}";
    }

    public virtual string GetTitle(Entity.Memorabilia memorabilia)
    {
        return string.Empty;
    }

    public virtual string ItemTypeText(Entity.Memorabilia memorabilia)
    {
        return memorabilia.ItemType?.Name ?? string.Empty;
    }

    public virtual string PlayerTeamText(Entity.Memorabilia memorabilia)
    {
        if (memorabilia.Autographs.Count == 1)
        {
            return memorabilia.Autographs.First().Person.ProfileName;
        }
        else
        {
            return memorabilia.Teams.Count switch
            {
                0 => string.Empty,
                1 => memorabilia.Teams.First().Team.Name,
                > 1 => "Multi Team",
                _ => string.Empty,
            };
        }
    }

    public virtual string SizeText(Entity.Memorabilia memorabilia)
    {
        return Constant.Size.Find(memorabilia.Size?.SizeId ?? 0)?.Name ?? string.Empty;
    }

    private static string ProfitLossText(Entity.Memorabilia memorabilia)
    {
        var value = (memorabilia.EstimatedValue ?? 0) + memorabilia.Autographs?.Sum(autograph => autograph?.EstimatedValue ?? 0);
        var cost = (memorabilia.MemorabiliaAcquisition?.Acquisition?.Cost ?? 0)
            + memorabilia.Autographs?.Sum(autograph => autograph?.Acquisition?.Cost ?? 0);

        var profitLoss = value - cost;

        return $"{(profitLoss > 0 ? "Profit" : "Loss")}: {profitLoss.Value.ToString("C") ?? string.Empty}";
    }
}

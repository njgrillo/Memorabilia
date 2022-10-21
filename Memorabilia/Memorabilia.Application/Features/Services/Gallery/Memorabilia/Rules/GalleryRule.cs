namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public abstract class GalleryRule
{
    public virtual string AcquisitionTypeText(Domain.Entities.Memorabilia memorabilia)
    {
        return $"Acquired:{Domain.Constants.AcquisitionType.Find(memorabilia.MemorabiliaAcquisition?.Acquisition?.AcquisitionTypeId ?? 0)?.Name ?? string.Empty}";
    }

    public virtual string AutographTitleText(Domain.Entities.Memorabilia memorabilia)
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

    public virtual string ConditionText(Domain.Entities.Memorabilia memorabilia)
    {
        return $"Condition: {memorabilia.Condition?.Name ?? string.Empty}";
    }

    public virtual string CostText(Domain.Entities.Memorabilia memorabilia)
    {
        var cost = (memorabilia.MemorabiliaAcquisition?.Acquisition?.Cost ?? 0) 
            + memorabilia.Autographs?.Sum(autograph => autograph?.Acquisition?.Cost ?? 0);

        return $"Cost: {cost?.ToString("C") ?? string.Empty}";
    }

    public virtual string EstimatedValueText(Domain.Entities.Memorabilia memorabilia)
    {
        var value = (memorabilia.EstimatedValue ?? 0) + memorabilia.Autographs?.Sum(autograph => autograph?.EstimatedValue ?? 0);

        return $"Value: {value?.ToString("C") ?? string.Empty}";
    }

    public virtual string GetDescription(Domain.Entities.Memorabilia memorabilia)
    {
        return $"{ConditionText(memorabilia)}, {AcquisitionTypeText(memorabilia)}";
    }

    public virtual string GetSubtitle(Domain.Entities.Memorabilia memorabilia)
    {
        return $"{CostText(memorabilia)}, {EstimatedValueText(memorabilia)}, {ProfitLossText(memorabilia)}";
    }

    public virtual string GetTitle(Domain.Entities.Memorabilia memorabilia)
    {
        return string.Empty;
    }

    public virtual string ItemTypeText(Domain.Entities.Memorabilia memorabilia)
    {
        return memorabilia.ItemType?.Name ?? string.Empty;
    }

    public virtual string PlayerTeamText(Domain.Entities.Memorabilia memorabilia)
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

    public virtual string SizeText(Domain.Entities.Memorabilia memorabilia)
    {
        return Domain.Constants.Size.Find(memorabilia.Size?.SizeId ?? 0)?.Name ?? string.Empty;
    }

    private static string ProfitLossText(Domain.Entities.Memorabilia memorabilia)
    {
        var value = (memorabilia.EstimatedValue ?? 0) + memorabilia.Autographs?.Sum(autograph => autograph?.EstimatedValue ?? 0);
        var cost = (memorabilia.MemorabiliaAcquisition?.Acquisition?.Cost ?? 0)
            + memorabilia.Autographs?.Sum(autograph => autograph?.Acquisition?.Cost ?? 0);

        var profitLoss = value - cost;

        return $"{(profitLoss > 0 ? "Profit" : "Loss")}: {profitLoss.Value.ToString("C") ?? string.Empty}";
    }
}

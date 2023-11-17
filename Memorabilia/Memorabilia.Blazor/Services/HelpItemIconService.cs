namespace Memorabilia.Blazor.Services;

public class HelpItemIconService
{
    public static string GetIcon(HelpItem helpItem)
        => helpItem.Id switch
            {
                1 => Icons.Material.TwoTone.Home,
                2 => Icons.Material.TwoTone.AttachMoney,
                3 => Icons.Material.TwoTone.Person,
                4 => Icons.Material.TwoTone.Collections,
                5 => Icons.Material.TwoTone.Dashboard,
                6 => Icons.Material.TwoTone.Feedback,
                7 => Icons.Material.TwoTone.Sell,
                8 => Icons.Material.TwoTone.SwapHoriz,
                9 => Icons.Material.TwoTone.Favorite,
                10 => Icons.Material.TwoTone.Image,
                11 => Icons.Material.TwoTone.Email,
                12 => Icons.Material.TwoTone.AttachMoney,
                13 => Icons.Material.TwoTone.Event,
                14 => Icons.Material.TwoTone.Task,
                15 => Icons.Material.TwoTone.SwapHoriz,
                16 => Icons.Material.TwoTone.SavedSearch,
                17 => Icons.Material.TwoTone.Settings,
                18 => Icons.Material.TwoTone.MarkunreadMailbox,
                19 => Icons.Material.TwoTone.AttachMoney,
                20 => Icons.Material.TwoTone.Forum,
                21 => Icons.Material.TwoTone.Image,
                22 => Icons.Material.TwoTone.Event,
                23 => Icons.Material.TwoTone.RateReview,
                24 => Icons.Material.TwoTone.PersonSearch,
                25 => Icons.Material.TwoTone.Carpenter,
                26 => Icons.Material.TwoTone.PersonSearch,
                27 => Icons.Material.TwoTone.SportsBaseball,
                28 => Icons.Material.TwoTone.SportsBasketball,
                29 => Icons.Material.TwoTone.SportsFootball,
                30 => Icons.Material.TwoTone.SportsHockey,
                31 => Icons.Material.TwoTone.Sports,
                32 => Icons.Material.TwoTone.RateReview,
                33 => Icons.Material.TwoTone.PersonSearch,
                _ => string.Empty,
            };
}

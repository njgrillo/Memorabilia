using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class ItemType
    {
        public static readonly ItemType Bammer = new(32, "Bammer");
        public static readonly ItemType Baseball = new(1, "Baseball");
        public static readonly ItemType Basketball = new(2, "Basketball");
        public static readonly ItemType Bat = new(3, "Bat");
        public static readonly ItemType Bobble = new(34, "Bobblehead");
        public static readonly ItemType Book = new(4, "Book");       
        public static readonly ItemType Bookplate = new(26, "Bookplate");       
        public static readonly ItemType Canvas = new(6, "Canvas");
        public static readonly ItemType CerealBox = new(35, "Cereal Box");
        public static readonly ItemType CompactDisc = new(28, "CD");
        public static readonly ItemType Document = new(36, "Document");
        public static readonly ItemType Drum = new(30, "Drum");        
        public static readonly ItemType Figure = new(8, "Figure");
        public static readonly ItemType FirstDayCover = new(5, "First Day Cover");
        public static readonly ItemType Football = new(9, "Football");
        public static readonly ItemType Glove = new(10, "Glove");
        public static readonly ItemType GolfBall = new(42, "Golf Ball");       
        public static readonly ItemType Guitar = new(29, "Guitar");
        public static readonly ItemType Hat = new(23, "Hat");
        public static readonly ItemType HeadBand = new(41, "Head Band");
        public static readonly ItemType Helmet = new(11, "Helmet");
        public static readonly ItemType HockeyStick = new(21, " Hockey Stick");
        public static readonly ItemType IndexCard = new(27, "Index Card");
        public static readonly ItemType Jersey = new(12, "Jersey");
        public static readonly ItemType JerseyNumber = new(13, "Jersey Number");
        public static readonly ItemType Lithograph = new(24, "Lithograph");
        public static readonly ItemType Magazine = new(14, "Magazine");
        public static readonly ItemType Other = new(15, "Other");
        public static readonly ItemType Painting = new(16, "Painting");
        public static readonly ItemType Pants = new(39, "Pants");
        public static readonly ItemType Photo = new(17, "Photo");
        public static readonly ItemType PinFlag = new(43, "Pin Flag");
        public static readonly ItemType PlayingCard = new(31, "Playing Card");
        public static readonly ItemType Poster = new(33, "Poster");
        public static readonly ItemType Puck = new(18, "Puck");        
        public static readonly ItemType Pylon = new(19, "Pylon");
        public static readonly ItemType Shirt = new(37, "Shirt");
        public static readonly ItemType Shoe = new(25, "Shoe");   
        public static readonly ItemType Soccerball = new(20, "Soccer Ball");
        public static readonly ItemType Tennisball = new(44, "Tennis Ball");
        public static readonly ItemType TennisRacket = new(45, "Tennis Racket");
        public static readonly ItemType Ticket = new(22, "Ticket");
        public static readonly ItemType TradingCard = new(7, "Trading Card");
        public static readonly ItemType Trunks = new(38, "Trunks");
        public static readonly ItemType WristBand = new(40, "Wrist Band");

        public static readonly ItemType[] All =
        {
            Bammer,
            Baseball,
            Basketball,
            Bat,
            Bobble,
            Book,
            Bookplate,
            Canvas,
            CerealBox,
            CompactDisc,
            Document,
            Drum,
            Figure,
            FirstDayCover,
            Football,
            Glove,
            GolfBall,
            Guitar,
            Hat,
            HeadBand,
            Helmet,
            HockeyStick,
            IndexCard,
            Jersey,
            JerseyNumber,
            Lithograph,
            Magazine,
            Other,
            Painting,
            Pants,
            Photo,
            PinFlag,
            PlayingCard,
            Poster,
            Puck,
            Pylon,
            Shirt,
            Shoe,
            Soccerball,
            Tennisball,
            TennisRacket,
            Ticket,
            TradingCard,
            Trunks,
            WristBand
        };

        public static readonly ItemType[] GameTypes =
        {
            Baseball,
            Basketball,
            Bat,
            Football,
            Glove,
            GolfBall,
            Hat,
            HeadBand,
            Helmet,
            HockeyStick,
            Jersey,
            Pants,
            PinFlag,
            Puck,
            Pylon,
            Shirt,
            Shoe,
            Soccerball,
            Tennisball,
            TennisRacket,
            Trunks,
            WristBand
        };

        public static readonly ItemType[] SpotTypes =
        {
            Bammer,
            Baseball,
            Bobble,
            Book,
            CompactDisc,
            Figure,
            FirstDayCover,
            Glove,
            Guitar,
            Hat,
            Helmet,
            HockeyStick,
            Jersey,
            Magazine,
            Pants,
            PinFlag,
            PlayingCard,
            Shirt,
            Shoe,
            Tennisball,
            TennisRacket,
            TradingCard,
            Trunks
        };

        public static readonly ItemType[] WearableTypes =
        {
            Glove,
            Hat,
            HeadBand,
            Helmet,
            Jersey,
            Pants,
            Shirt,
            Shoe,
            Trunks,
            WristBand
        };

        private ItemType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static bool CanHaveSpot(ItemType itemType)
        {
            return SpotTypes.Contains(itemType);
        }

        public static ItemType Find(int id)
        {
            return All.SingleOrDefault(itemType => itemType.Id == id);
        }

        public static bool IsGameType(ItemType itemType)
        {
            return GameTypes.Contains(itemType);
        }

        public static bool IsWearable(ItemType itemType)
        {
            return WearableTypes.Contains(itemType);
        }
    }
}

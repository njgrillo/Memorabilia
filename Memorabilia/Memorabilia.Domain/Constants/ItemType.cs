using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class ItemType
    {
        public static readonly ItemType Baseball = new(1, "Baseball");
        public static readonly ItemType Basketball = new(2, "Basketball");
        public static readonly ItemType Bat = new(3, "Bat");
        public static readonly ItemType Book = new(4, "Book");
        public static readonly ItemType Cachet = new(5, "Cachet");
        public static readonly ItemType Canvas = new(6, "Canvas");
        public static readonly ItemType Card = new(7, "Card");
        public static readonly ItemType Figure = new(8, "Figure");
        public static readonly ItemType Football = new(9, "Football");
        public static readonly ItemType Glove = new(10, "Glove");
        public static readonly ItemType Helmet = new(11, "Helmet");
        public static readonly ItemType HockeyStick = new(21, " Hockey Stick");
        public static readonly ItemType Jersey = new(12, "Jersey");
        public static readonly ItemType JerseyNumber = new(13, "Jersey Number");
        public static readonly ItemType Magazine = new(14, "Magazine");
        public static readonly ItemType Other = new(15, "Other");
        public static readonly ItemType Painting = new(16, "Painting");
        public static readonly ItemType Photo = new(17, "Photo");        
        public static readonly ItemType Puck = new(18, "Puck");        
        public static readonly ItemType Pylon = new(19, "Pylon");        
        public static readonly ItemType SoccerBall = new(20, "Soccer Ball");   
        public static readonly ItemType TicketStub = new(22, "Ticket Stub");        

        public static readonly ItemType[] All =
        {
            Baseball,
            Basketball,
            Bat,
            Book,
            Cachet,
            Canvas,
            Card,
            Figure,
            Football,
            Glove,
            Helmet,
            HockeyStick,
            Jersey,
            JerseyNumber,
            Magazine,
            Other,
            Painting,
            Photo,
            Puck,
            Pylon,
            SoccerBall,
            TicketStub 
        };

        private ItemType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public static ItemType Find(int id)
        {
            return All.SingleOrDefault(itemType => itemType.Id == id);
        }
    }
}

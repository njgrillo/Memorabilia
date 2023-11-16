namespace Memorabilia.Domain.Constants;

public sealed class BallotNumber : DomainItemConstant
{
    public static readonly BallotNumber Eighth = new(8, "8th");
    public static readonly BallotNumber Eleventh = new(11, "11th");
    public static readonly BallotNumber Fifth = new(5, "5th");
    public static readonly BallotNumber Fifthteenth = new(15, "15th");
    public static readonly BallotNumber First = new(1, "1st");
    public static readonly BallotNumber Fourth = new(4, "4th");
    public static readonly BallotNumber Fourteenth = new(14, "14th");
    public static readonly BallotNumber Nineth = new(9, "9th");
    public static readonly BallotNumber Second = new(2, "2nd");
    public static readonly BallotNumber Seventh = new(7, "7th");
    public static readonly BallotNumber Sixteenth = new(16, "16th");
    public static readonly BallotNumber Sixth = new(6, "6th");
    public static readonly BallotNumber Tenth = new(10, "10th");
    public static readonly BallotNumber Third = new(3, "3rd");
    public static readonly BallotNumber Thirteenth = new(13, "13th");
    public static readonly BallotNumber Twelveth = new(12, "12th");

    public static readonly BallotNumber[] All =
    [
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eighth,
        Nineth,
        Tenth,
        Eleventh,
        Twelveth,
        Thirteenth,
        Fourteenth,
        Fifthteenth,
        Sixteenth
    ];

    private BallotNumber(int id, string name) 
        : base(id, name) { }

    public static BallotNumber Find(int id)
        => All.SingleOrDefault(ballotNumber => ballotNumber.Id == id);
}

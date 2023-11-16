namespace Memorabilia.Domain.Constants;

public sealed class MembershipPaymentType : DomainItemConstant
{
    public static readonly MembershipPaymentType OneTime = new(1, "Try for one month");
    public static readonly MembershipPaymentType Recurring = new(2, "Enroll in auto-renewal");

    public static readonly MembershipPaymentType[] All =
    [
        OneTime,
        Recurring
    ];

    private MembershipPaymentType(int id, string name)
        : base(id, name) { }
}

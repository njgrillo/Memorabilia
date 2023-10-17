﻿namespace Memorabilia.Blazor.Models.PaypalClient;

public class SellerReceivableBreakdown
{
    public Amount gross_amount { get; set; }

    public Amount net_amount { get; set; }

    public PaypalFee paypal_fee { get; set; }    
}

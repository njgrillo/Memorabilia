namespace Memorabilia.Blazor.Client.Paypal;

public class PaypalClient(IDataProtectorService dataProtectorService,
                          IPaypalSettings paypalSettings) 
    : IPaypalClient
{
    public async Task<CaptureOrderResponse> CaptureOrder(string orderId)
    {
        var auth = await Authenticate();

        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization 
            = AuthenticationHeaderValue.Parse($"Bearer {auth.access_token}");

        var httpContent = new StringContent("", Encoding.Default, "application/json");

        HttpResponseMessage httpResponse 
            = await httpClient.PostAsync($"{paypalSettings.BaseUrl}/v2/checkout/orders/{orderId}/capture", httpContent);

        string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<CaptureOrderResponse>(jsonResponse);

        return response;
    }

    public async Task<CreateOrderResponse> CreateOrder(PaypalOrderModel order)
    {
        AuthResponse auth = await Authenticate();

        string encryptedOrderId
            = dataProtectorService.Encrypt(order.Reference);

        var request = new CreateOrderRequest
        {
            intent = "CAPTURE",
            purchase_units =
                [
                    new()
                    {
                        reference_id = order.Reference,
                        amount = new Amount
                        {
                            currency_code = order.Currency,
                            value = order.Price
                        },
                        payee = new Payee
                        {
                            email_address = order.Seller.EmailAddress
                        },
                        payment_instruction = new PaymentInstruction
                        {
                            disbursement_mode = "INSTANT"
                        }
                    }
                ],
            application_context = new ApplicationContext
            {
                cancel_url = $"https://localhost:44332/paypal/cancel?OrderId={encryptedOrderId}",
                return_url = $"https://localhost:44332/paypal/confirm?OrderId={encryptedOrderId}",
            },
            payment_source = new PaymentSource
            {
                paypal = new Models.PaypalClient.Paypal
                {
                    email_address = order.Buyer.EmailAddress,
                    experience_content = new ExperienceContent
                    {
                        locale = "en-US",
                        payment_method_preference = "IMMEDIATE_PAYMENT_REQUIRED",
                        user_action = "PAY_NOW"
                    },
                    name = new Name
                    {
                        given_name = $"{order.Buyer.FirstName} {order.Buyer.LastName}" 
                    }
                }
            }
        };

        var httpClient = new HttpClient();

        httpClient.DefaultRequestHeaders.Authorization
            = AuthenticationHeaderValue.Parse($"Bearer {auth.access_token}");

        HttpResponseMessage httpResponse 
            = await httpClient.PostAsJsonAsync($"{paypalSettings.BaseUrl}/v2/checkout/orders", request);

        string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<CreateOrderResponse>(jsonResponse);

        return response;
    }

    private async Task<AuthResponse> Authenticate()
    {
        var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{paypalSettings.ClientId}:{paypalSettings.ClientSecret}"));

        var content = new List<KeyValuePair<string, string>>
            {
                new("grant_type", "client_credentials")
            };

        var request = new HttpRequestMessage
        {
            RequestUri = new Uri($"{paypalSettings.BaseUrl}/v1/oauth2/token"),
            Method = HttpMethod.Post,
            Headers =
                {
                    { "Authorization", $"Basic {auth}" }
                },
            Content = new FormUrlEncodedContent(content)
        };

        var httpClient = new HttpClient();
        HttpResponseMessage httpResponse = await httpClient.SendAsync(request);
        string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<AuthResponse>(jsonResponse);

        return response;
    }
}

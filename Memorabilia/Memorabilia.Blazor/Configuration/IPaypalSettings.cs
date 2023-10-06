namespace Memorabilia.Blazor.Configuration;

public interface IPaypalSettings
{
    string BaseUrl { get; }

    string ClientId { get; set; }

    string ClientSecret { get; set; }

    string Mode { get; set; }    
}

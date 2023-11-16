﻿namespace Memorabilia.Application.Features.Autograph.Authentication;

public class AuthenticationsModel : Model
{
    public AuthenticationsModel() { }

    public AuthenticationsModel(IEnumerable<Entity.AutographAuthentication> authentications)
    {
        Authentications = authentications.Select(authentication => new AuthenticationModel(authentication))
                                         .ToList();
    }

    public int AutographId { get; set; }

    public string ImageFileName { get; set; }

    public List<AuthenticationModel> Authentications { get; set; } 
        = [];

    public override string PageTitle 
        => "Authentications";
}

﻿namespace Memorabilia.Application.Features.User.Register;

public class UserEditModel : EditModel
{
    public UserEditModel() { }

    public string EmailAddress { get; set; }

    public string FirstName { get; set; }

    public string GoogleEmailAddress { get; set; }

    public string LastName { get; set; }

    public string MicrosoftEmailAddress { get; set; }

    public string Username { get; set; }

    public string XHandle { get; set; }
}

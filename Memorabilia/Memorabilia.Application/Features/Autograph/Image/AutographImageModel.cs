﻿namespace Memorabilia.Application.Features.Autograph.Image;

public class AutographImageModel : ImageModel
{
    private readonly Entity.AutographImage _image;

    public AutographImageModel() { }

    public AutographImageModel(Entity.AutographImage image)
    {
        _image = image;
    }

    public int AutographId => _image.AutographId;
}

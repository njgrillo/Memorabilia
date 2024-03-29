﻿using Memorabilia.Domain.Entities;
using Memorabilia.Application.Features.Image;

namespace Memorabilia.Application.Features.Autograph.Image
{
    public class AutographImageViewModel : ImageViewModel
    {
        private readonly AutographImage _image;

        public AutographImageViewModel() { }

        public AutographImageViewModel(AutographImage image)
        {
            _image = image;
        }

        public int AutographId => _image.AutographId;
    }
}

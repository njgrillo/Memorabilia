﻿namespace Memorabilia.Application.Features.Image;

public class ImageEditModel : EditModel
{
    public ImageEditModel() { }

    public ImageEditModel(ImageModel viewModel)
    {
        FileName = viewModel.FileName;
        Id = viewModel.Id;
        ImageTypeId = viewModel.ImageTypeId;
    }

    public ImageEditModel(Entity.Image image)
    {
        FileName = image.FileName;
        Id = image.Id;
        ImageTypeId = image.ImageTypeId;
    }

    public string FileName { get; set; }

    public Constant.ImageType ImageType 
        => Constant.ImageType.Find(ImageTypeId);

    [Required]
    public int ImageTypeId { get; set; }

    public bool IsPrimary 
        => ImageTypeId == Constant.ImageType.Primary.Id;

    [Required]
    public DateTime UploadDate { get; set; }

    public override string PageTitle 
        => $"{(Id > 0 ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} Image";
}

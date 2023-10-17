namespace Memorabilia.Application.Models.Payments.Stripe;

public class ProductModel
{
	public ProductModel() { }

	public ProductModel(string description,						
						string name,
                        List<string> imageUrls = null)
	{
		Description = description;		
		Name = name;

		if (imageUrls != null)
			ImageUrls = imageUrls;
    }

	public string Description { get; set; }

	public List<string> ImageUrls { get; set; }

	public string Name { get; set; }	
}

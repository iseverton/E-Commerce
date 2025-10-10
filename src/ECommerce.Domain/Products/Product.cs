using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Products;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    //public ICollection<Category> Categories { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int QuantityInStock { get; set; }


    public ICollection<Review>? Reviews { get; set; }


    public Product(string name, string description, decimal price, string pictureUrl, string type, string brand, int quantityInStock)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        Type = type;
        Brand = brand;
        QuantityInStock = quantityInStock;
    }
}

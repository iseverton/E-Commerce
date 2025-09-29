using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public int QuantityInStock { get; set; }

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

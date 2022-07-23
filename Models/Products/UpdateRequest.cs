namespace WebApi.Models.Products;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Price { get; set; }

    public string Peremption { get; set; }
}
namespace WebApi.Models.Products;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Price { get; set; }

    [Required]
    public string Peremption { get; set; }

}
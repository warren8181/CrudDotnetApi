namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Products;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private IProductService _productService;
    private IMapper _mapper;

    public ProductsController(
        IProductService productService,
        IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productService.GetById(id);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _productService.Create(model);
        return Ok(new { message = "Product created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _productService.Update(id, model);
        return Ok(new { message = "Product updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return Ok(new { message = "Product deleted" });
    }
}
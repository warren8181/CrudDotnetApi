namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Products;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class ProductService : IProductService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products;
    }

    public Product GetById(int id)
    {
        return getProduct(id);
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.Products.Any(x => x.Code == model.Code))
            throw new AppException("Product with this Code '" + model.Code + "' already exists");

        // map model to new user object
        var product = _mapper.Map<Product>(model);

        // save user
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var product = getProduct(id);

        // validate
        if (model.Code != product.Code && _context.Products.Any(x => x.Code == model.Code))
            throw new AppException("Product with this Code '" + model.Code + "' already exists");

        // copy model to user and save
        _mapper.Map(model, product);
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = getProduct(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    // helper methods

    private Product getProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) throw new KeyNotFoundException("Product not found");
        return product;
    }
}
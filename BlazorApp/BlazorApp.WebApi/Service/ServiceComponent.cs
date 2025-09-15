using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.WebApi.Service
{
    public interface IServiceComponent
    {
        List<Product> GetProducts();
        Product GetProduct(int id);

        void AddProduct(Product product);
        void UpdateProduct(Product product,int id);
        void DeleteProduct(int id);
    }
    public class ServiceComponent : IServiceComponent
    {
        private readonly Data.ApplicationDbContext _context;
        public ServiceComponent(Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
        [HttpPost]
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        [HttpPut("{id}")]
        public void UpdateProduct(Product product,int id)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                _context.SaveChanges();
            }
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        
    }
}
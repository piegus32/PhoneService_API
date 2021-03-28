using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Product.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Product.Remove(product);
        }

        public IEnumerable<Product> GetListProducts()
        {
            return _context.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Product.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProduct(Product product)
        {
            //Update
        }
    }
}

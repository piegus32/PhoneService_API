using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Data
{
    public interface IProductRepo
    {
        //Persist changes
        bool SaveChanges();

        //Get All products from data
        IEnumerable<Product> GetListProducts();

        //Get Product by ID
        Product GetProductById(int id);

        //Post Create new product
        void CreateProduct(Product product);

        //Update product
        void UpdateProduct(Product cmd);

        //Delete product
        void DeleteProduct(Product product);
    }
}

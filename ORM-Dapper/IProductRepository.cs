using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ORM_Dapper;

public interface IProductRepository
{
     public IEnumerable<Product> GetAllProducts();
     public Product GetProduct(int id);
     public void UpdateProduct(Product product);
     public void DeleteProduct(int id);
     
}
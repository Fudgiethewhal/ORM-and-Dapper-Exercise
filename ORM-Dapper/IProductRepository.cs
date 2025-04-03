using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ORM_Dapper;

public interface IProductRepository
{
     IEnumerable<Product> GetAllProducts();
}
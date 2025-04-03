using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;


namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public DapperProductRepository(IDbConnection conn)
    {
        _conn = conn;   
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM product;");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM product WHERE productID = @id;",
            new { id });
        }

    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products" +
                      "Set Name = @name," +
                      "Price= @price," +
                      "CategoryID = @catID," +
                      "OnSale = @onSale," +
                      "StockLevel = @stock" +
                      "WHERE productID = @id;",
            new
            {
                name = product.Name,
                price = product.Price,
                catID = product.CategoryID,
                OnSale = product.OnSale,
                stock = product.StockLevel
            });
    }
}

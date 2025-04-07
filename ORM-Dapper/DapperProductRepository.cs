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

    public void CreateProduct(string name, double price, int categoryID)
    {
        _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES ( @productName, @price, @categoryID);",
            new {productName = name, price = price, categoryID = categoryID });
    }
    public IEnumerable<Product> GetAllProducts()
    {
       return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
    }

    public void UpdateProductName(int productID, string updatedName)
    {
        _conn.Execute("UPDATE products SET Name = @updatedName WHERE  ProductID = @productID;",
            new { updatedName = updatedName, productID = productID });
    }

    public void DeleteProduct(int productID)
    {
        _conn.Execute("DELETE FROM reviews WHERE ProductID =  @productID;",
            new { productID = productID });
        _conn.Execute("DELETE FROM sales WHERE ProductID = @productID;",
            new { productID = productID });
        _conn.Execute("DELETE FROM products WHERE ProductID = @productID;",
            new { productID = productID });
    }
}

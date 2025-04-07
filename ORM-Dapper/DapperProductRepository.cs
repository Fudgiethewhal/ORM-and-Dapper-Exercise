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

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;",
            new { id = id });
    }

    public void UpdateProduct(Product product)
    {
        _conn.Execute(
            "UPDATE products"+
            " SET Name = @name," +
            " Price = @price," +
            " CategoryID = @catID," +
            " OnSale = @onSale," +
            " StockLevel = @stockLevel;" +
            " WHERE ProductID = @id;",
            new {
                    id = product.ProductID,
                    name = product.Name,
                    price = product.Price,
                    categoryID = product.CategoryID,
                    onSale = product.OnSale,
                    stockLevel = product.StockLevel     
                });
            
    }
    

    public void DeleteProduct(int id)
    {
        _conn.Execute("DELETE FROM sales WHERE ProductID =  @id;", new { id = id});

        _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id = id });
        _conn.Execute("DELETE FROM products WHERE ProductID = @id;", new { id = id });
    }
}

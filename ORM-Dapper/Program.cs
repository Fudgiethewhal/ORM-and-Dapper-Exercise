using ORM_Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Text;



namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            var repo = new DapperProductRepository(conn);

            var products = repo.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.CategoryID} {prod.Name}");
            }
            
            repo.CreateProduct("newStuff", 20, 1);
            var productRepository = new DapperProductRepository(conn);

            var productToUpdate = productRepository.GetProduct(940);
            

            productRepository.UpdateProduct(productToUpdate);

            productToUpdate.Name = "Updated!!!";
            productToUpdate.Price = 12.99;
            productToUpdate.CategoryID = 1;
            productToUpdate.OnSale = false;
            productToUpdate.StockLevel = 1000;
            
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
                
            }
        }

    }
}

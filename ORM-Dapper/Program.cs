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
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            
            var productRepository = new DapperProductRepository(conn);

            var products = productRepository.GetAllProducts();
            
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }

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
            
            

            Console.WriteLine("Hello user, here are the current departments");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();

            var departmentRepo = new DapperDepartmentRepository();
            departmentRepo.InsertDepartment(Bryseida's new Department);
            var deparments = departmentRepo.GetAllDepartments();
            
            foreach (var department in deparments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
            
            Console.WriteLine("Do you want to add a department???");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department?");
                userInput = Console.ReadLine();
                repo.InsertDepartment(userInput);
                Print(repo.GetAllDepartments());
            }
            
            Console.WriteLine("Have a great day.");
        }

        private static void Print(IEnumerable<Department> departments)
        {
            foreach (var department in departments)
            {
                Console.WriteLine($"Id: {department.DepartmentID} Name: {department.Name}");
            }
            
        }

    }
}

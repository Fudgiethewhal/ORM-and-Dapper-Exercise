using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

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
        return _conn.Query<Product>("SELECT * FROM product");
    }
}
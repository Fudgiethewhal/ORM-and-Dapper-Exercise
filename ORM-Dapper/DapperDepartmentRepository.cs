using Dapper;   
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _conn;

    public DapperDepartmentRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        var departments = _conn.Query<Department>("SELECT * FROM departments");
        return departments;

    }

    public void InsertDepartment(string newDepartmentName)
    {
        _conn.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
    }
}
using Dapper;
using DEMO.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.API.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port = 3306;"
                + "User = dev;"
                + "Password = 12345678;"
                + "Database = MF824_DVTRUNG_AMIS;"
                 + "convert zero datetime = True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            /*string sqlCommand = "SELECT * FROM Employee";

            var listEmployees = dbConnection.Query<Employee>(sqlCommand, commandType: CommandType.Text);*/

            string sqlCommand = "Proc_GetAllEmployees";

            var listEmployees = dbConnection.Query<Employee>(sqlCommand, commandType: CommandType.StoredProcedure);

            if (listEmployees.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listEmployees);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port = 3306;"
                + "User = dev;"
                + "Password = 12345678;"
                + "Database = MF824_DVTRUNG_AMIS;"
                 + "convert zero datetime = True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            /*string sqlCommand = "Proc_GetEmployeeById";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);*/

            string sqlCommand = $"SELECT * FROM Employee e WHERE e.EmployeeId = '{id}'";

            /*var employee = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);*/

            var employee = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, commandType: CommandType.Text);

            if(employee == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPost]
        public IActionResult Insert(Employee employee)
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port = 3306;"
                + "User = dev;"
                + "Password = 12345678;"
                + "Database = MF824_DVTRUNG_AMIS;"
                +"convert zero datetime = True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            string sqlCommand = $"INSERT INTO Employee(EmployeeId, EmployeeCode, FullName, DateOfBirth, DepartmentId) VALUES(UUID(), '{employee.EmployeeCode}', '{employee.FullName}', '{employee.DateOfBirth}', '{employee.DepartmentId}')";

            var rowAffects = dbConnection.Execute(sqlCommand, commandType: CommandType.Text);

            if(rowAffects <= 0)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(201, rowAffects);
            }
        }
    }
}

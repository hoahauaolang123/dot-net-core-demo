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
    [Route("api/v1/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port=3306;"
                + "User=dev;"
                + "Password=12345678;"
                + "Database=MF824_DVTRUNG_AMIS;"
                + "convert zero datetime =True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            string sqlCommand = "Proc_GetAllDepartments";
            var listDepartment = dbConnection.Query<Department>(sqlCommand, commandType: CommandType.StoredProcedure);

            if (listDepartment.Count() <= 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listDepartment);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port=3306;"
                + "User=dev;"
                + "Password=12345678;"
                + "Database=MF824_DVTRUNG_AMIS;"
                + "convert zero datetime = True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            string sqlCommand = "Proc_GetDepartmentById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", id);
            var derpartment = dbConnection.QueryFirstOrDefault<Department>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);
            if (derpartment == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(derpartment);
            }
        }
        [HttpPost]
        public IActionResult InsertDepartment( Department department)
        {
            string connectionString = "Host = 47.241.69.179;"
                + "Port=3306;"
                + "User=dev;"
                + "Password=12345678;"
                + "Database=MF824_DVTRUNG_AMIS;"
                + "convert zero datetime = True";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            string sqlCommand = "Proc_InsertDepartment";
            var rowAffects = dbConnection.Execute(sqlCommand,param:department, commandType: CommandType.StoredProcedure);
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

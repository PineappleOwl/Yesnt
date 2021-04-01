using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Graph;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;

namespace OkMooi.Pages
{
    public class Class : PageModel
    {
        public IDbConnection IDbConnection { get; private set; }

        public IDbConnection Connect()
        {
            string connectionstring = @"Server=127.0.0.1;
                                        Port=3306;
                                        Database=mydb;
                                        Uid=root;
                                        Pwd=;";

            return new MySqlConnection(connectionstring);
        }




        public List<Tables> Get()
        {
            using var connection = Connect();
            var Tables = connection
                .Query<Tables>("SELECT * FROM Tables");
            return (List<Tables>)Tables;
        }



        public bool AddSimple(Todo todo)
        {
            using var connection = Connect();
            int numRowEffected = connection.Execute(
                @"INSERT INTO Todo (Description, Done) VALUES (@Description, @Done)"
                , todo);
            return numRowEffected == 1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkMooi.Pages
{
    public class DBRepos
    {
               public IDbConnection Connect()
        {
            string connectionString = @"Server=127.0.0.1;Port=3306;Database=hoekstrafotografie;Uid=root;Pwd='';";
            return new MySqlConnection(connectionString);
        }
    }
}

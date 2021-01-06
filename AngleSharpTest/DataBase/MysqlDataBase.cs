using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngleSharpTest.DataBase
{
    public class MysqlDataBase
    {

       public static MySqlConnection con = new MySqlConnection("server=localhost; uid=root;pwd=820822;port=3306;database=job;SslMode=None;pooling=true;min pool size = 3;");




        public static int insertOrupdate(string sql,Object list)
        {
            int outlist = 0;
           con.Open();

            outlist = con.Execute(sql, list);

            con.Close();
            return outlist;

        }



        public static IEnumerable<T> select<T>(string sql,Object lists)
        {

            IEnumerable<T> list = con.Query<T>(sql, lists);
            return list;

        }
    }
}

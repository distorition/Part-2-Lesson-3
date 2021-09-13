using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Part_2_Lesson_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConectDBController : ControllerBase
    {
        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";//В переменной cs мы создаем строку подключения к базе данны
            string stm = "SELECT SQLITE_VERSION()";//Затем мы создаем строку с запросом, которую отправим в базу данных  При помощи оператора SELECT мы выбираем данные,
            using (var con=new SQLiteConnection(cs))
            {
                con.Open();
                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();
                return Ok(version);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Http;
using Peoples.Models;

namespace Peoples.Controllers
{
    public class PeoplesController : ApiController
    {
        private MySqlConnection GetConnection()
        {
            string connectString = "data source=127.0.0.1;database=fastlink;user id=root;password=123456;pooling=false;charset=utf8";//pooling代表是否使用连接池
            //string connectString = "data source=127.0.0.1;database=test;user id=root;password=123456;pooling=false;charset=utf8";//pooling代表是否使用连接池

            //string connectString = "data source=127.0.0.1;database=fastlink;user id=root;password=admin;pooling=false;charset=utf8";//pooling代表是否使用连接池
            MySqlConnection conn = new MySqlConnection(connectString);
            conn.Open();
            return conn;
        }
        [Route("api/peoples")]
        // GET api/peoples
        public IEnumerable<people> Get()
        {
            List<people> list = new List<people>();
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "select * from peoples";
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        people line = new people();
                        int id = 0;
                        int.TryParse(reader["id"].ToString(), out id);
                        line.Id = id;
                        line.Name = reader["name"].ToString();
                        DateTime dt = DateTime.MinValue;
                        DateTime.TryParse(reader["birthday"].ToString(), out dt);
                        line.Birthday = dt.ToString("yyyy-MM-dd");
                        line.Telephone = reader["telephone"].ToString();
                        list.Add(line);
                    }
                }
            }
            return list.ToArray();
        }
        [HttpGet]
        //注意：如果想通过Get请求AA/index/names，可以在Get前面加Route。

        [Route("api/peoples/{name}")]
        // GET api/peoples/zhangsan
        public people Get(string name)
        {
            people line = new people();
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "select * from peoples" + " where name=@name ";
                    com.Parameters.AddWithValue("@name", name);
                    MySqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {

                        int id = 0;
                        int.TryParse(reader["id"].ToString(), out id);
                        line.Id = id;
                        line.Name = reader["name"].ToString();
                        DateTime dt = DateTime.MinValue;
                        DateTime.TryParse(reader["birthday"].ToString(), out dt);
                        line.Birthday = dt.ToString("yyyy-MM-dd");
                        line.Telephone = reader["telephone"].ToString();

                    }
                }
            }
            return line;
        }
        //create
        [HttpPost]
        [Route("api/peoples")]
        // POST: api/Users
        public void Post([FromBody]people line)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "insert into peoples(name, birthday, telephone) values (@name, @birthday, @telephone) ";
                    com.Parameters.AddWithValue("@name", line.Name);
                    com.Parameters.AddWithValue("@birthday", line.Birthday);
                    com.Parameters.AddWithValue("@telephone", line.Telephone);
                    com.ExecuteNonQuery();
                }
            }
        }

        [HttpPut]
        [Route("api/peoples/{name}")]
        // PUT: api/Users/5
        public void Put(string name, [FromBody]people line)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "update peoples set birthday=@birthday, telephone=@telephone where name=@name ";
                    com.Parameters.AddWithValue("@name", name);
                    com.Parameters.AddWithValue("@birthday", line.Birthday);
                    com.Parameters.AddWithValue("@telephone", line.Telephone);
                    com.ExecuteNonQuery();
                }
            }
        }

        [HttpDelete]
        [Route("api/peoples/{name}")]
        // DELETE: api/Users/5
        public void Delete(string name)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "delete from peoples where name=@name ";
                    com.Parameters.AddWithValue("@name", name);
                    com.ExecuteNonQuery();
                }
            }
        }
    }
}

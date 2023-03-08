using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web.Http;

using Peoples.Models;
namespace product.Controllers
{
    public class ProductController : ApiController
    {
        private MySqlConnection GetConnection()
        {
            string connectString = "data source=127.0.0.1;database=fastlink;user id=root;password=123456;pooling=false;charset=utf8";//pooling代表是否使用连接池

            //string connectString = "data source=127.0.0.1;database=fastlink;user id=root;password=admin;pooling=false;charset=utf8";//pooling代表是否使用连接池
            MySqlConnection conn = new MySqlConnection(connectString);
            conn.Open();
            return conn;
        }
        // [Route("api/product")]
        [Route("api/product")]
        // GET api/product
        public IEnumerable<Product> Get()
        {
            List<Product> list = new List<Product>();
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "select * from product";
                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        //csharp orm 
                        //people line = new people();
                        Product line
                            = new Product();
                        //int id = 0;
                        //int.TryParse(reader["id"].ToString(), out id);
                        //line.Id = id;
                        //line.Name = reader["name"].ToString();
                        //DateTime dt = DateTime.MinValue;
                        //DateTime.TryParse(reader["birthday"].ToString(), out dt);
                        //line.Birthday = dt.ToString("yyyy-MM-dd");
                        //line.Telephone = reader["telephone"].ToString();
                        //list.Add(line);

                        //DateTime create_time = DateTime.Now;
                        //DateTime.TryParse(reader["create_time"].ToString(), out create_time);

                        //int id = 0;
                        //int.TryParse(reader["id"].ToString(), out id);
                        //line.Id = id;
                        //string name = reader["name"].ToString();

                        //string product_code = reader["product_code"].ToString();

                        //string specification = reader["specification"].ToString();

                        DateTime create_time = DateTime.Now;
                        DateTime.TryParse(reader["create_time"].ToString(), out create_time);
                        line.create_time = create_time;

                        int id = 0;
                        int.TryParse(reader["id"].ToString(), out id);
                        line.id = id;

                        //line.id = id;

                        string name = reader["name"].ToString();
                        line.name = name;

                        string product_code = reader["product_code"].ToString();
                        line.product_code = product_code;

                        string specification = reader["specification"].ToString();
                        line.specification = specification;
                        list.Add(line);
                    }
                }
            }
            return list.ToArray();
        }

        [HttpPost]
        [Route("api/product/selectPage")]
        // GET api/product
        //, int pageIndex, int pageSize
        public object selectPage([FromBody] Product postData)
        {
            List<Product> list = new List<Product>();
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    string sql = "select * from product   ";

                    List<string> values = new List<string>();

                    //自动  postData.create_time
                    //0001 / 1 / 1 0:00:00
                    if (postData.create_time != null)
                    {
                        values.Add($" create_time = @create_time ");
                        com.Parameters.AddWithValue("@create_time", postData.create_time);
                    }


                    if (postData.id != null)
                    {
                        values.Add($" id = @id ");
                        com.Parameters.AddWithValue("@id", postData.id);
                    }


                    if (postData.name != null)
                    {
                        values.Add($" name = @name ");
                        com.Parameters.AddWithValue("@name", postData.name);
                    }


                    if (postData.product_code != null)
                    {
                        values.Add($" product_code = @product_code ");
                        com.Parameters.AddWithValue("@product_code", postData.product_code);
                    }


                    if (postData.specification != null)
                    {
                        values.Add($" specification = @specification ");
                        com.Parameters.AddWithValue("@specification", postData.specification);
                    }



                    string whereCondition = string.Join(" \n and ", values);

                    if (values.Count > 0)
                    {
                        sql += "  where  " + whereCondition;
                    }
                    //charp print 
                    System.Console.WriteLine("sql");
                    System.Console.WriteLine(sql);
                    System.Diagnostics.Debug.WriteLine("sql");
                    System.Diagnostics.Debug.WriteLine(sql);

                    System.Diagnostics.Debug.WriteLine("postData");
                    System.Diagnostics.Debug.WriteLine(postData);
                    System.Diagnostics.Debug.WriteLine(postData.ToString());

                    System.Diagnostics.Debug.WriteLine("postData.create_time");
                    System.Diagnostics.Debug.WriteLine(postData.create_time);


                    com.CommandText = sql;

                    MySqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Product line = new Product();

                        DateTime create_time = DateTime.Now;
                        DateTime.TryParse(reader["create_time"].ToString(), out create_time);
                        line.create_time = create_time;

                        int id = 0;
                        int.TryParse(reader["id"].ToString(), out id);

                        line.id = id;

                        string name = reader["name"].ToString();
                        line.name = name;

                        string product_code = reader["product_code"].ToString();
                        line.product_code = product_code;

                        string specification = reader["specification"].ToString();
                        line.specification = specification;
                        list.Add(line);
                    }
                }
            }
            return list.ToArray();
        }


        [HttpGet]
        //注意：如果想通过Get请求AA/index/names，可以在Get前面加Route。

        [Route("api/product/{name}")]
        // GET api/product/zhangsan
        public people Get(string name)
        {
            people line = new people();
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "select * from product" + " where name=@name ";
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
        //[HttpPost]
        //[Route("api/product")]
        //// POST: api/Users
        //public void Post([FromBody]people line)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "insert into product(name, birthday, telephone) values (@name, @birthday, @telephone) ";
        //            com.Parameters.AddWithValue("@name", line.Name);
        //            com.Parameters.AddWithValue("@birthday", line.Birthday);
        //            com.Parameters.AddWithValue("@telephone", line.Telephone);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //}

        //create
        [HttpPost]
        [Route("api/product")]
        // POST: api/product
        public object Post([FromBody] Product line)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "insert into product(create_time, id, name, product_code, specification) values (@create_time, @id, @name, @product_code, @specification) ";
                    com.Parameters.AddWithValue("@create_time", line.create_time);
                    com.Parameters.AddWithValue("@id", line.id);
                    com.Parameters.AddWithValue("@name", line.name);
                    com.Parameters.AddWithValue("@product_code", line.product_code);
                    com.Parameters.AddWithValue("@specification", line.specification);
                    com.ExecuteNonQuery();
                }
            }
            //csharp 返回一个 实体
            return ReturnT.Ok("ok");
        }

        //[HttpPut]
        //[Route("api/product/{name}")]
        //// PUT: api/Users/5
        //public void Put(string name, [FromBody]people line)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "update product set birthday=@birthday, telephone=@telephone where name=@name ";
        //            com.Parameters.AddWithValue("@name", name);
        //            com.Parameters.AddWithValue("@birthday", line.Birthday);
        //            com.Parameters.AddWithValue("@telephone", line.Telephone);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //}

        //[HttpPut]
        //[Route("api/product/{name}")]
        //// PUT: api/Users/5
        //public void Put( [FromBody] Product line)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "update product set birthday=@birthday, telephone=@telephone where name=@name ";
        //            com.Parameters.AddWithValue("@name", name);
        //            com.Parameters.AddWithValue("@birthday", line.Birthday);
        //            com.Parameters.AddWithValue("@telephone", line.Telephone);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //}

        //[HttpDelete]
        //[Route("api/product/{name}")]
        //// DELETE: api/Users/5
        //public void Delete(string name)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "delete from product where name=@name ";
        //            com.Parameters.AddWithValue("@name", name);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //}

        //[HttpPost]
        //[Route("api/product/put")]
        //// PUT: api/product/5
        //public object Put([FromBody] Product line)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "update product set create_time = @create_time, name = @name, product_code = @product_code, specification = @specification where id=@id ";
        //            com.Parameters.AddWithValue("@create_time", line.create_time);
        //            com.Parameters.AddWithValue("@id", line.id);
        //            com.Parameters.AddWithValue("@name", line.name);
        //            com.Parameters.AddWithValue("@product_code", line.product_code);
        //            com.Parameters.AddWithValue("@specification", line.specification);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //    return ReturnT.Ok("ok");
        //}

        //[HttpPost]
        //[Route("api/product/{name}")]
        //// DELETE: api/product/5
        //public object Delete([FromBody] Product line)
        //{
        //    using (MySqlConnection conn = this.GetConnection())
        //    {
        //        using (MySqlCommand com = new MySqlCommand())
        //        {
        //            com.Connection = conn;
        //            com.CommandText = "delete from product where id=@id ";
        //            com.Parameters.AddWithValue("@id", line.id);
        //            com.ExecuteNonQuery();
        //        }
        //    }
        //    return ReturnT.Ok("ok");
        //}


        [HttpPost]
        [Route("api/product/put")]
        // PUT: api/product/5
        public object Put([FromBody] Product line)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "update product set create_time = @create_time, name = @name, product_code = @product_code, specification = @specification where id=@id ";
                    com.Parameters.AddWithValue("@create_time", line.create_time);
                    com.Parameters.AddWithValue("@id", line.id);
                    com.Parameters.AddWithValue("@name", line.name);
                    com.Parameters.AddWithValue("@product_code", line.product_code);
                    com.Parameters.AddWithValue("@specification", line.specification);
                    com.ExecuteNonQuery();
                }
            }
            return ReturnT.Ok("ok");
        }

        [HttpPost]
        [Route("api/product/delete")]
        // DELETE: api/product/5
        public object Delete([FromBody] Product line)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "delete from product where id=@id ";
                    com.Parameters.AddWithValue("@id", line.id);
                    com.ExecuteNonQuery();
                }
            }
            return ReturnT.Ok("ok");
        }




    }
}

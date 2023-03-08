
using FreeSql.DataAnnotations;
using System;

public class Product
{

    //public int create_time { get; set; }
    //public int id { get; set; }
    //public int name { get; set; }
    //public int product_code { get; set; }
    //public int specification { get; set; }

    [Column(IsIdentity = true, IsPrimary = true)]
    //public int id { get; set; }
    public int? id { get; set; }

    //public   id { get; set; }
    //csharp 包装类 int 

    public DateTime? create_time { get; set; }

    public string name { get; set; }
    public string product_code { get; set; }
    public string specification { get; set; }
}
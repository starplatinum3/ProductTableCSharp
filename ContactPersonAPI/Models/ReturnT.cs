
using System;

public class ReturnT
{

    //public int create_time { get; set; }
    //public int id { get; set; }
    //public int name { get; set; }
    //public int product_code { get; set; }
    //public int specification { get; set; }
    public int code { get; set; }
    public string msg { get; set; }
    public object data { get; set; }

    static int codeSucess=200;
    static int codeError = 500;
    public static ReturnT Ok(object data) {
        //csharp new 一个实体
        ReturnT returnT= new ReturnT();
        returnT.code = codeSucess;
        returnT.msg = "ok";
        returnT.data = data;
        return returnT;
}

    public static ReturnT Error(object data)
    {
        //csharp new 一个实体
        ReturnT returnT = new ReturnT
        {
            code = codeError,
            msg = "error",
            data = data
        };
        return returnT;
    }

    //[Column(IsIdentity = true, IsPrimary = true)]
    //public int id { get; set; }
    //public DateTime create_time { get; set; }

    //public string name { get; set; }
    //public string product_code { get; set; }
    //public string specification { get; set; }
}
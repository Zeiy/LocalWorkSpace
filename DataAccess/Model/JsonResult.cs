using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
     public class JsonResult
    {
         public int Status { get; set; }
         public string Msg { get; set; }
         public string Url { get; set; }
         public object Result { get; set; }
    }
}

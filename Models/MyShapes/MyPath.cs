using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models.MyShapes
{
    public class MyPath : MyShape
    {
        public MyPath() { }
        public string Data { get; set; }
        public string Fill { get; set; }
    }
}

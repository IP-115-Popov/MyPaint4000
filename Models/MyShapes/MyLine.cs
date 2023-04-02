using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models.MyShapes
{
    public class MyLine : MyShape
    {
        public MyLine() { }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models.MyShapes
{
    public class MyRectangle : MyShape
    {
        public MyRectangle() { }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Margin { get; set; }
        public string? MarginText { get; set; }
        public string? Fill { get; set; }
    }
}

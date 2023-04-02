using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models.MyShapes
{
    public class MyShape
    {
        public MyShape() { }
        public string? Name { get; set; }
        public double StrokeThickness { get; set; }
        public string? Stroke { get; set; }
    }
}

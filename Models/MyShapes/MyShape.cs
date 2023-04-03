using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models.MyShapes
{
    public class MyShape : ITransformShape
    {
        public MyShape() 
        {
            TranslateTransformX = 0;
            TranslateTransformY = 0;
            RotateTransformAngleDeg = 0;
            RotateTransformCenterX = 0;
            RotateTransformCenterY = 0;
            ScaleTransformX = 1;
            ScaleTransformY = 1;
            SkewTransformAngleX = 0;
            SkewTransformAngleY = 0;
        }
        public string? Name { get; set; }
        public double StrokeThickness { get; set; }
        public string? Stroke { get; set; }
        //транформация
        public double TranslateTransformX { get; set; }
        public double TranslateTransformY { get; set; }
        public double RotateTransformAngleDeg { get; set; }
        public double RotateTransformCenterX { get; set; }
        public double RotateTransformCenterY { get; set ; }
        public double ScaleTransformX { get; set; }
        public double ScaleTransformY { get; set; }
        public double SkewTransformAngleX { get; set; }
        public double SkewTransformAngleY { get; set; }
    }
}

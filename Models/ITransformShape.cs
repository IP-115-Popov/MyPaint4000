using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models
{
    public interface ITransformShape
    {
        //изменение координат
        double TranslateTransformX { get; set; }
        double TranslateTransformY { get; set; }
        //угол поворота
        double RotateTransformAngleDeg { get; set; }
        //цетер во круг которого поворацивается
        double RotateTransformCenterX { get; set; }
        double RotateTransformCenterY { get; set; }
        //маштабирование
        double ScaleTransformX { get; set; }
        double ScaleTransformY { get; set; }
        //вытягивание по асям
        //угол наклона по асям
        double SkewTransformAngleX { get; set; }
        double SkewTransformAngleY { get; set; }
    }
}

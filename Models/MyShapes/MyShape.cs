using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Binding;

namespace MyPaint4000.Models.MyShapes
{
    public class MyShape : AbstractNotifyPropertyChanged, ITransformShape
    {
        private double translateTransformX;
        private double translateTransformY;
        private double rotateTransformAngleDeg;
        private double rotateTransformCenterX;
        private double rotateTransformCenterY;
        private double scaleTransformX;
        private double scaleTransformY;
        private double skewTransformAngleX;
        private double skewTransformAngleY;

        private double positionX;
        private double positionY;
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
        public double PositionX
        {
            get => positionX;
            set => SetAndRaise(ref positionX, value);
        }
        public double PositionY
        {
            get => positionY;
            set => SetAndRaise(ref positionY, value);
        }
        //транформация
        public double TranslateTransformX
        {
            get => translateTransformX;
            set => SetAndRaise(ref translateTransformX, value);
        }
        public double TranslateTransformY
        {
            get => translateTransformY;
            set => SetAndRaise(ref translateTransformY, value);
        }
        public double RotateTransformAngleDeg
        {
            get => rotateTransformAngleDeg;
            set => SetAndRaise(ref rotateTransformAngleDeg, value);
        }
        public double RotateTransformCenterX
        {
            get => rotateTransformCenterX;
            set => SetAndRaise(ref rotateTransformCenterX, value);
        }
        public double RotateTransformCenterY
        {
            get => rotateTransformCenterY;
            set => SetAndRaise(ref rotateTransformCenterY, value);
        }
        public double ScaleTransformX
        {
            get => scaleTransformX;
            set => SetAndRaise(ref scaleTransformX, value);
        }
        public double ScaleTransformY
        {
            get => scaleTransformY;
            set => SetAndRaise(ref scaleTransformY, value);
        }
        public double SkewTransformAngleX
        {
            get => skewTransformAngleX;
            set => SetAndRaise(ref skewTransformAngleX, value);
        }
        public double SkewTransformAngleY
        {
            get => skewTransformAngleY;
            set => SetAndRaise(ref skewTransformAngleY, value);
        }
    }
}

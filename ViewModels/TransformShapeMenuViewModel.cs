using Avalonia.Media;
using MyPaint4000.Models;
using MyPaint4000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.ViewModels
{
    public class TransformShapeMenuViewModel : ViewModelBase , ITransformShape
    {
        //поля транформации
        private double translateTransformX;
        private double translateTransformY;
        private double rotateTransformAngleDeg;
        private double rotateTransformCenterX;
        private double rotateTransformCenterY;
        private double scaleTransformX;
        private double scaleTransformY;
        private double skewTransformAngleX;
        private double skewTransformAngleY;
        //своиства трансформации
        public double TranslateTransformX
        {
            get => translateTransformX;
            set => this.RaiseAndSetIfChanged(ref translateTransformX, value);
        }
        public double TranslateTransformY
        {
            get => translateTransformY;
            set => this.RaiseAndSetIfChanged(ref translateTransformY, value);
        }
        public double RotateTransformAngleDeg
        {
            get => rotateTransformAngleDeg;
            set => this.RaiseAndSetIfChanged(ref rotateTransformAngleDeg, value);
        }
        public double RotateTransformCenterX
        {
            get => rotateTransformCenterX;
            set => this.RaiseAndSetIfChanged(ref rotateTransformCenterX, value);
        }
        public double RotateTransformCenterY
        {
            get => rotateTransformCenterY;
            set => this.RaiseAndSetIfChanged(ref rotateTransformCenterY, value);
        }
        public double ScaleTransformX
        {
            get => scaleTransformX;
            set => this.RaiseAndSetIfChanged(ref scaleTransformX, value);
        }
        public double ScaleTransformY
        {
            get => scaleTransformY;
            set => this.RaiseAndSetIfChanged(ref scaleTransformY, value);
        }
        public double SkewTransformAngleX
        {
            get => skewTransformAngleX;
            set => this.RaiseAndSetIfChanged(ref skewTransformAngleX, value);
        }
        public double SkewTransformAngleY
        {
            get => skewTransformAngleY;
            set => this.RaiseAndSetIfChanged(ref skewTransformAngleY, value);
        }
        public void SetDefault()
        {
            TranslateTransformX = 0;
            TranslateTransformY = 0;
            RotateTransformAngleDeg = 0;
            RotateTransformCenterX = 0;
            RotateTransformCenterY = 0;
            ScaleTransformX = 0;
            ScaleTransformY = 0;
            SkewTransformAngleX = 0;
            SkewTransformAngleY = 0;
    }
    }
}

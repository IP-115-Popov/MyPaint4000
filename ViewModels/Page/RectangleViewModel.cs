using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.ViewModels.Page
{
    public class RectangleViewModel : MyFigure
    {
        private string? x1Y1;
        private string? myWidth;
        private string? myHeight;
        private ISolidColorBrush? selectedColorFill;
        public RectangleViewModel()
        {
            header = "Прямоугольник";
            SelectedColorFill = new SolidColorBrush(Colors.Red);
        }
        public string? X1Y1
        {
            get => x1Y1;
            set => this.RaiseAndSetIfChanged(ref x1Y1, value);
        }
        public string? MyWidth
        {
            get => myWidth;
            set => this.RaiseAndSetIfChanged(ref myWidth, value);
        }
        public string? MyHeight
        {
            get => myHeight;
            set => this.RaiseAndSetIfChanged(ref myHeight, value);
        }
        public ISolidColorBrush? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
        }
        public override void SetDefault()
        {
            base.SetDefault();
            X1Y1 = null;
            MyWidth = null;
            MyHeight = null;
            SelectedColorFill = new SolidColorBrush(Colors.Red);
        }
    }
}

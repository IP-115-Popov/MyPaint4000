using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace MyPaint4000.ViewModels.Page
{
    public class PolygonViewModel : MyFigure
    {
        private string? myPoints;
        private ISolidColorBrush? selectedColorFill;
        public PolygonViewModel()
        {
            header = "Многоугольник";
            SelectedColorFill = new SolidColorBrush(Colors.Red);
        }
        public string? MyPoints
        {
            get => myPoints;
            set => this.RaiseAndSetIfChanged(ref myPoints, value);
        }
        public ISolidColorBrush? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
        }
        public override void SetDefault()
        {
            base.SetDefault();
            MyPoints = null;
            SelectedColorFill = new SolidColorBrush(Colors.Red);
        }
    }
}

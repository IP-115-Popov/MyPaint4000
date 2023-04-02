using Avalonia.Data.Core;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.ViewModels.Page
{
    public abstract class MyFigure : ViewModelBase
    {
        protected string? header = "Ломаная линия";

        protected string? name;
        protected int lineSize = 1;
        protected ISolidColorBrush? selectedColorLine;
        protected ObservableCollection<ISolidColorBrush?> colorList;
        public MyFigure()
        {
            SelectedColorLine = new SolidColorBrush(Colors.Red);
            ColorList = new ObservableCollection<ISolidColorBrush>(
                typeof(Brushes)
                .GetProperties()
                .Select(propertyInfo => (ISolidColorBrush)propertyInfo.GetValue(propertyInfo)));
        }
        public string? Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public int LineSize
        {
            get => lineSize;
            set => this.RaiseAndSetIfChanged(ref lineSize, value);
        }
        public ISolidColorBrush? SelectedColorLine
        {
            get => selectedColorLine;
            set => this.RaiseAndSetIfChanged(ref selectedColorLine, value);
        }
        public ObservableCollection<ISolidColorBrush?>? ColorList
        {
            get => colorList;
            set => this.RaiseAndSetIfChanged(ref colorList, value);
        }
        public string? Header
        {
            get => header;
        }
        public virtual void SetDefault()
        {
            Name = null;
            LineSize = 1;
            SelectedColorLine = new SolidColorBrush(Colors.Red);
        }
    }
}

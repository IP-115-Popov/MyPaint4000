using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.VisualTree;
using MyPaint4000.Models.MyShapes;
using MyPaint4000.ViewModels;
using System.IO;
using System.Linq;

namespace MyPaint4000.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(DragDrop.DropEvent, Drop);
        }
        private async void OpenFileXml(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0], "xml");
                }
            }
        }
        private async void OpenFileJson(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });
            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Load(path[0], "json");
                }
            }
        }


        private async void SaveFileXml(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Xml files",
                    Extensions = new string[] { "xml" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path, "xml");
                }
            }
        }
        private async void SaveFileJson(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "JSON files",
                    Extensions = new string[] { "json" }.ToList()
                });
            string? path = await saveFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is MainWindowViewModel dataContext)
                {
                    dataContext.Save(path, "json");
                }
            }
        }

        private async void SaveFilePng(object sender, RoutedEventArgs eventArgs)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filters.Add(
                new FileDialogFilter
                {
                    Name = "Png files",
                    Extensions = new string[] { "png" }.ToList()
                });
            string? result = await saveFileDialog.ShowAsync(this);
            var canvas = this.GetVisualDescendants().OfType<Canvas>().Where(canvas => canvas.Name.Equals("canvas")).FirstOrDefault();
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if (result != null)
                {
                    var pxsize = new PixelSize((int)canvas.Bounds.Width, (int)canvas.Bounds.Height);
                    var size = new Size(canvas.Bounds.Width, canvas.Bounds.Height);
                    using (RenderTargetBitmap bitmap = new RenderTargetBitmap(pxsize, new Avalonia.Vector(96, 96)))
                    {
                        canvas.Measure(size);
                        canvas.Arrange(new Rect(size));
                        bitmap.Render(canvas);
                        bitmap.Save(result);
                    }
                }
            }
        }

        private Point pointerPressedEvent;
        private Point pointerPositionInShape;
        private void PointerPressedOnCanvas(object? sender, PointerPressedEventArgs pointerPressedEventArgs)
        {
            //неведомо как получаем координаты нажати€ на конвас
            pointerPressedEvent = pointerPressedEventArgs.GetPosition(
                this.GetVisualDescendants()
                .OfType<Canvas>()
                .FirstOrDefault());
            //провер€ю с помощю "Source" событие сгенерированно фигурой
            if (pointerPressedEventArgs.Source is Shape shape)
            {
                //коодринаты указател€ в нутри фигуры
                pointerPositionInShape = pointerPressedEventArgs.GetPosition(shape);
                this.PointerMoved += PointerMoveDragShape;
                this.PointerReleased += PointerReleasedDragShape;
            }
        }
        private void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (pointerEventArgs.Source is Shape shape)
            {
                Point currentPointPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>().FirstOrDefault());
                if (shape.DataContext is MyShape MuvedShape)
                {
                    MuvedShape.TranslateTransformX = currentPointPosition.X - shape.Width/2;
                    MuvedShape.TranslateTransformY = currentPointPosition.Y - shape.Height/2;
                }
            }
        }
        private void PointerReleasedDragShape(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasedDragShape;
        }

        private void Drop(object? sender, DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.Contains(DataFormats.FileNames)) 
            {
                string? filename = dragEventArgs.Data.GetFileNames()?.FirstOrDefault();
                if (filename != null)
                {
                    if (this.DataContext is MainWindowViewModel dataContext)
                    {
                        dataContext.Load(filename, (System.IO.Path.GetExtension(filename)).Substring(1));
                    }
                }
            }
        }
    }
}

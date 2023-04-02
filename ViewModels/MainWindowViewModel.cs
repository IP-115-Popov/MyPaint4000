using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DynamicData;
using MyPaint4000.Models.MyShapes;
using MyPaint4000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text;
using System.Xml.Serialization;
using static Avalonia.OpenGL.GlInterface;

namespace MyPaint4000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<MyShape> canvasFigureList;
        //настраиваемая фигура
        private MyFigure? myFigure;
        //список настраивыемых фигур
        private ObservableCollection<MyFigure> myFiguresList;

        BrokenLineViewModel brokenLineViewModel;
        CompoundFigureViewModel compoundFigureViewModel;
        EllipseViewModel ellipseViewModel;
        PolygonViewModel polygonViewModel;
        RectangleViewModel rectangleViewModel;
        StraightLineViewModel straightLineViewModel;
        public MainWindowViewModel() 
        {
            //список фигур для отображения на холсте и в списке фигур
            canvasFigureList = new ObservableCollection<MyShape>();

            MyFigure = new StraightLineViewModel();
            brokenLineViewModel = new BrokenLineViewModel();
            compoundFigureViewModel = new CompoundFigureViewModel();
            ellipseViewModel = new EllipseViewModel();
            polygonViewModel = new PolygonViewModel();
            rectangleViewModel = new RectangleViewModel();
            straightLineViewModel = new StraightLineViewModel();
            myFiguresList = new ObservableCollection<MyFigure>() { brokenLineViewModel, compoundFigureViewModel, ellipseViewModel, polygonViewModel, rectangleViewModel, straightLineViewModel };

            MyClear = ReactiveCommand.Create(() =>
            {
                if (myFigure != null) MyFigure.SetDefault();
            });
            AddMyFigure = ReactiveCommand.Create(() =>
            {
                //удаляем элемент с такимже именем
                string nameAddItem = myFigure.Name;
                foreach (MyShape i in canvasFigureList)
                {
                    if (i.Name == nameAddItem)
                    {
                        CanvasFigureList.Remove(i);
                        break;
                    }
                }
                if (myFigure is BrokenLineViewModel) AddBrokenLine();
                else if (myFigure is CompoundFigureViewModel) AddCompoundFigure();
                else if (myFigure is EllipseViewModel) AddEllipse();
                else if (myFigure is PolygonViewModel) AddPolygon();
                else if (myFigure is RectangleViewModel) AddRectangle();
                else if (myFigure is StraightLineViewModel) AddStraightLine();
            });
            DelItem = ReactiveCommand.Create<MyShape>((returnedMyFigure) =>
            {
                CanvasFigureList.Remove(returnedMyFigure);
            });
        }
        public ReactiveCommand<Unit, Unit> AddMyFigure { get; set; }
        public ReactiveCommand<Unit, Unit>? MyClear { get; set; }
        public ReactiveCommand<MyShape, Unit>? DelItem { get; set; }
        public void Load(string path, string extension)
        {
            if (extension == "json")
            {
            }
            else if (extension == "xml")
            {
            }
        }
        public void Save(string path, string extension)
        {
            if (extension == "json")
            {
            }
            else if (extension == "xml")
            {
            }
        }
        public MyFigure? MyFigure
        {
            get => myFigure;
            set => this.RaiseAndSetIfChanged(ref myFigure, value);
        }
        public ObservableCollection<MyFigure> MyFiguresList
        {
            get => myFiguresList;
            set => this.RaiseAndSetIfChanged(ref myFiguresList, value);
        }
        public ObservableCollection<MyShape> CanvasFigureList
        {
            get => canvasFigureList;
            set => this.RaiseAndSetIfChanged(ref canvasFigureList, value);
        }
        private void AddBrokenLine()
        {
            CanvasFigureList.Add(new MyPolyline()
            {
                Name = brokenLineViewModel.Name,              
                Stroke = brokenLineViewModel.SelectedColorLine.ToString(),
                StrokeThickness = brokenLineViewModel.LineSize,
                Points = brokenLineViewModel.MyPoints,
            });
        }
        private void AddCompoundFigure()
        {
            CanvasFigureList.Add(new MyPath()
            {
                Name = compoundFigureViewModel.Name,
                Stroke = compoundFigureViewModel.SelectedColorLine.ToString(),
                StrokeThickness = brokenLineViewModel.LineSize,
                Data = compoundFigureViewModel.MyPoints,
                Fill = compoundFigureViewModel.SelectedColorFill.ToString()
            });
        }
        private void AddEllipse()
        {
            CanvasFigureList.Add(new MyEllipse()
            {
                Name = ellipseViewModel.Name,
                Stroke = ellipseViewModel.SelectedColorLine.ToString(),
                StrokeThickness = ellipseViewModel.LineSize,
                Fill = ellipseViewModel.SelectedColorFill.ToString(),
                Height = ellipseViewModel.MyWidth,
                Width = ellipseViewModel.MyHeight,
                Margin = ellipseViewModel.X1Y1,
                
            });
        }
        private void AddPolygon()
        {
            CanvasFigureList.Add(new MyPolygon()
            {
                Name = polygonViewModel.Name,
                Stroke = polygonViewModel.SelectedColorLine.ToString(),
                StrokeThickness = polygonViewModel.LineSize,
                Fill = compoundFigureViewModel.SelectedColorFill.ToString(),
                Points = compoundFigureViewModel.MyPoints              
            });
        }
        private void AddRectangle()
        {
            CanvasFigureList.Add(new MyRectangle()
            {
                Name = rectangleViewModel.Name,
                Stroke = rectangleViewModel.SelectedColorLine.ToString(),
                StrokeThickness = rectangleViewModel.LineSize,
                Fill = rectangleViewModel.SelectedColorFill.ToString(),
                Height = rectangleViewModel.MyWidth,
                Width = rectangleViewModel.MyHeight,
                Margin = rectangleViewModel.X1Y1           
            });
        }
        private void AddStraightLine()
        {
            CanvasFigureList.Add(new MyLine()
            {
                Name = straightLineViewModel.Name,
                Stroke = straightLineViewModel.SelectedColorLine.ToString(),
                StrokeThickness = straightLineViewModel.LineSize,
                StartPoint = straightLineViewModel.X1Y1,
                EndPoint = straightLineViewModel.X2Y2,              
            });
        }
    }
}

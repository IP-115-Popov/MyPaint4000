using MyPaint4000.Models;
using MyPaint4000.Models.MyShapes;
using MyPaint4000.ViewModels.Page;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Xml.Serialization;

namespace MyPaint4000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //���� ��������� ������
        private ViewModelBase transformShapeMenu;
        //���������������� ������
        private MyShape? nowTransformShape;
        private ObservableCollection<MyShape> canvasFigureList;
        //������������� ������
        private ViewModelBase? myFigure;
        //������ ������������� �����
        private ObservableCollection<MyFigure> myFiguresList;

        BrokenLineViewModel brokenLineViewModel;
        CompoundFigureViewModel compoundFigureViewModel;
        EllipseViewModel ellipseViewModel;
        PolygonViewModel polygonViewModel;
        RectangleViewModel rectangleViewModel;
        StraightLineViewModel straightLineViewModel;
        public MainWindowViewModel() 
        {
            transformShapeMenu = new TransformShapeMenuViewModel();
            //������ ����� ��� ����������� �� ������ � � ������ �����
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
                if (myFigure != null && myFigure is MyFigure) ((MyFigure)myFigure).SetDefault();
                if (myFigure != null && myFigure is TransformShapeMenuViewModel) ((TransformShapeMenuViewModel)myFigure).SetDefault();
            });
            AddMyFigure = ReactiveCommand.Create(() =>
            {
                if (myFigure != MyFigure) return;
                //������� ������� � ������� ������
                string nameAddItem = ((MyFigure)myFigure).Name;
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
                CanvasFigureList.Clear();               
                using (StreamReader file = new StreamReader(path))
                {
                    ForSerialaizerSapes saverConvas = Newtonsoft.Json.JsonConvert.DeserializeObject<ForSerialaizerSapes>(file.ReadToEnd());
                    CanvasFigureList = saverConvas.DeSerializeCanvas();
                }
            }
            else if (extension == "xml")
            {
                CanvasFigureList.Clear();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ForSerialaizerSapes));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    ForSerialaizerSapes saverConvas = xmlSerializer.Deserialize(fs) as ForSerialaizerSapes;
                    CanvasFigureList = saverConvas.DeSerializeCanvas();
                }
            }
        }
        public void Save(string path, string extension)
        {
            if (extension == "json")
            {
                ForSerialaizerSapes saverConvas = new ForSerialaizerSapes();
                saverConvas.SerializeCanvas(canvasFigureList);
                string? jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(saverConvas);
                if (jsonData != null)
                {
                    using (StreamWriter file = new StreamWriter(path, false))
                    {
                        file.Write(jsonData);
                    }
                }
            }
            else if (extension == "xml")
            {
                ForSerialaizerSapes saverConvas = new ForSerialaizerSapes();
                saverConvas.SerializeCanvas(canvasFigureList);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ForSerialaizerSapes));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, saverConvas);
                }
            }
        }
        //���������������� ������
        public MyShape? NowTransformShape
        {
            get => nowTransformShape;
            set
            {
                this.RaiseAndSetIfChanged(ref nowTransformShape, value);
                MyFigure = transformShapeMenu;
            }
        }
        public ViewModelBase? MyFigure
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
                Fill = polygonViewModel.SelectedColorFill.ToString(),
                Points = polygonViewModel.MyPoints              
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

using Avalonia.Controls.Shapes;
using Avalonia.Media;
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
                CanvasFigureList.Clear();
                using (StreamReader file = new StreamReader(path))
                {
                    CanvasListSerialize lol = Newtonsoft.Json.JsonConvert.DeserializeObject<CanvasListSerialize>(file.ReadToEnd());
                    CanvasFigureList = lol.DeSerializeCanvas();
                }
            }
            else if (extension == "xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CanvasListSerializeXml));
                CanvasListSerializeXml test4 = new CanvasListSerializeXml();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    test4 = xmlSerializer.Deserialize(fs) as CanvasListSerializeXml;
                }

                CanvasFigureList = test4.DeSerializeCanvas();
            }
        }
        public void Save(string path, string extension)
        {
            if (extension == "json")
            {
                CanvasListSerialize test3 = new CanvasListSerialize();
                test3.SerializeCanvas(canvasFigureList);
                string? jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(test3);
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
                CanvasListSerializeXml test4 = new CanvasListSerializeXml();
                test4.SerializeCanvas(canvasFigureList);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CanvasListSerializeXml));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, test4);
                }
            }
            else if (extension == "png")
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

        }
        private void AddCompoundFigure()
        {
        }
        private void AddEllipse()
        {
        }
        private void AddPolygon()
        {
        }
        private void AddRectangle()
        {
        }
        private void AddStraightLine()
        {
        }
    }
}

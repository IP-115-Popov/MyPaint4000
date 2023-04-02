using Avalonia.Controls.Shapes;
using DynamicData;
using DynamicData.Binding;
using MyPaint4000.Models.MyShapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.Models
{
    public class ForSerialaizerSapes
    {  
        public List<MyEllipse> MyEllipseList { get; set; }
        public List<MyLine> MyLineList { get; set; }
        public List<MyPath> MyPathList { get; set; }
        public List<MyPolygon> MyPolygonList { get; set; }
        public List<MyPolyline> MyPolylineList { get; set; }
        public List<MyRectangle> MyRectangleList { get; set; }

        public ForSerialaizerSapes() 
        {
            MyEllipseList = new List<MyEllipse>();
            MyLineList = new List<MyLine>();
            MyPathList = new List<MyPath>();
            MyPolygonList = new List<MyPolygon>();
            MyPolylineList = new List<MyPolyline>();
            MyRectangleList = new List<MyRectangle>();
        }
        public void SerializeCanvas(ObservableCollection<MyShape> canvasFigureList)
        {
            foreach (MyShape shape in canvasFigureList)
            {
                if (shape is MyEllipse) MyEllipseList.Add((MyEllipse)shape);
                else if (shape is MyLine) MyLineList.Add((MyLine)shape);
                else if (shape is MyPath) MyPathList.Add((MyPath)shape);
                else if (shape is MyPolygon) MyPolygonList.Add((MyPolygon)shape);
                else if (shape is MyPolyline) MyPolylineList.Add((MyPolyline)shape);
                else if (shape is MyRectangle) MyRectangleList.Add((MyRectangle)shape);
            }
        }
        public ObservableCollection<MyShape> DeSerializeCanvas()
        {
            ObservableCollection < MyShape > canvasFigureList = new ObservableCollection<MyShape>();
            foreach (MyEllipse shape in MyEllipseList) canvasFigureList.Add(shape);
            foreach (MyLine shape in MyLineList) canvasFigureList.Add(shape);
            foreach (MyPath shape in MyPathList) canvasFigureList.Add(shape);
            foreach (MyPolygon shape in MyPolygonList) canvasFigureList.Add(shape);
            foreach (MyPolyline shape in MyPolylineList) canvasFigureList.Add(shape);
            foreach (MyRectangle shape in MyRectangleList) canvasFigureList.Add(shape);
            return canvasFigureList;
        }
    }
}

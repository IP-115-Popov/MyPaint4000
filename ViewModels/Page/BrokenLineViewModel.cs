using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.ViewModels.Page
{
    public class BrokenLineViewModel : MyFigure
    {
        private string? myPoints;
        public BrokenLineViewModel() : base()
        {
            header = "Ломаная линия";
        }
        public string? MyPoints
        {
            get => myPoints;
            set => this.RaiseAndSetIfChanged(ref myPoints, value);
        }
        public override void SetDefault()
        {
            base.SetDefault();
            MyPoints = null;
        }
    }
}

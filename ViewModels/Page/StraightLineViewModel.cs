using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint4000.ViewModels.Page
{
    public class StraightLineViewModel : MyFigure
    {
        private string? x1Y1;
        private string? x2Y2;
        public StraightLineViewModel()
        {
            header = "Прямая линия";
        }
        public string? X1Y1
        {
            get => x1Y1;
            set => this.RaiseAndSetIfChanged(ref x1Y1, value);
        }
        public string? X2Y2
        {
            get => x2Y2;
            set => this.RaiseAndSetIfChanged(ref x2Y2, value);
        }
        public override void SetDefault()
        {
            base.SetDefault();
            X1Y1 = null;
            X2Y2 = null;
        }
    }
}

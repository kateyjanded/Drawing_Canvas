using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CCTP
{
    /// <summary>
    /// Interaction logic for hexagon.xaml
    /// </summary>
    public partial class hexagon : UserControl
    {
        public hexagon()
        {
            InitializeComponent();
        }

        private Canvas canv;
        Point mouselocation;

        private bool isdraggable;

        public bool Isdraggable
        {
            get { return Isdraggable; }
            set { Isdraggable = value; }
        }

        private bool ismoveable;
        public hexagon(hexagon hexa, Canvas cav)
        {
            InitializeComponent();
            Canvas c = new Canvas();
            canv = cav;
            this.HexagonUI.Height = hexa.HexagonUI.Height;
            this.HexagonUI.Width = hexa.HexagonUI.Width;
            this.HexagonUI.Fill = hexa.HexagonUI.Fill;
            Isdraggable = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (ismoveable == true)
            {
                mouselocation = e.GetPosition(canv);
                double left = mouselocation.X - this.ActualWidth / 2;
                double top = mouselocation.Y - this.ActualHeight / 2;
                Canvas.SetTop(this, top);
                Canvas.SetLeft(this, left);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            ismoveable = false;
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            if (Isdraggable == false)
            {
                DataObject Data = new DataObject();
                Data.SetData(DataFormats.StringFormat, HexagonUI.Fill.ToString());
                Data.SetData("double", Height);
                Data.SetData("Object", this);
                DragDrop.DoDragDrop(this, Data, DragDropEffects.Copy);
            }
            else
            {
                ismoveable = true;
            }
        }
    }
}

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
    /// Interaction logic for triangle.xaml
    /// </summary>
    public partial class triangle : UserControl
    {
        public triangle()
        {
            InitializeComponent();
        }

        private bool ismoveable;
        public bool Ismoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }

        private Point mouselocation;
        private bool isdraggable;
        bool adorneradd = true;
        simpleadorner simple;
        AdornerLayer myAdornerLayer;
        public triangle(triangle tri, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.triangleUI.Height = tri.triangleUI.Height;
            this.triangleUI.Width = tri.triangleUI.Width;
            this.triangleUI.Fill = tri.triangleUI.Fill;
            Ismoveable = true;
        }

        private Canvas canv;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable == true)
            {
                mouselocation = e.GetPosition(canv);
                double left = mouselocation.X - (this.ActualWidth / 2);
                double top = mouselocation.Y - (this.ActualHeight / 2);

                double canvaswidth = 600;
                double canvasheight = 570;

                if (left < 0)
                {
                    left = 0;
                }
                else if (left + this.ActualWidth > canvaswidth)
                {
                    left = canvaswidth - this.ActualWidth;
                }
                if (top < 0)
                {
                    top = 0;
                }
                else if (top + this.ActualHeight > canvasheight)
                {
                    top = canvasheight - this.ActualHeight;
                }
                Canvas.SetTop(this, top);
                Canvas.SetLeft(this, left);
            }
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            isdraggable = false;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (Ismoveable == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, triangleUI.Fill.ToString());
                data.SetData("Double", triangleUI.Height);
                data.SetData("Object", this);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy);
            }
            else
            {
                isdraggable = true;
            }
        }
    }
}

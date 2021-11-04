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
    /// Interaction logic for rectangle.xaml
    /// </summary>
    public partial class rectangle : UserControl
    {
        public rectangle()
        {
            InitializeComponent();
        }

        private Canvas canv;
        Point mouselocation;
        //bool adorneradd = true;
        //simpleadorner simple;
        //AdornerLayer myAdornerLayer;
        private bool Ismoveable;

        public bool ismoveable
        {
            get { return Ismoveable; }
            set { Ismoveable = value; }
        }
        private bool isdraggable = false;
        public rectangle(rectangle recta, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.rectangleUI.Height = recta.rectangleUI.ActualHeight;
            this.rectangleUI.Width = recta.rectangleUI.ActualWidth;
            this.rectangleUI.Fill = recta.rectangleUI.Fill;
            ismoveable = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if( isdraggable == true)
            {
                mouselocation = e.GetPosition(canv);
                double top = mouselocation.Y - (rectangleUI.ActualHeight / 2);
                double left = mouselocation.X - (rectangleUI.ActualWidth / 2);

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
            isdraggable= false;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (ismoveable == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, rectangleUI.Fill.ToString());
                data.SetData("Double", Height);
                data.SetData("Double", Width);
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

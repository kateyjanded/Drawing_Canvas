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
    /// Interaction logic for pentagon.xaml
    /// </summary>
    public partial class pentagon : UserControl
    {
        public pentagon()
        {
            InitializeComponent();
        }
        private Canvas canv;
        Point mouselocation;
        simpleadorner simple;
        AdornerLayer myAdornerLayer;

        private bool ismoveable;

        public bool Ismoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }
        bool isdraggable = false;

        public pentagon(pentagon pen, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.pentagonUI.Height = pen.pentagonUI.Height;
            this.pentagonUI.Width = pen.pentagonUI.Width;
            this.pentagonUI.Fill = pen.pentagonUI.Fill;
            Ismoveable = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable == true)
            {
                mouselocation = e.GetPosition(canv);
                double left = mouselocation.X - (this.ActualHeight / 2);
                double top = mouselocation.Y - (this.ActualWidth / 2);

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
        bool adorneradd = true;
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (Ismoveable == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, pentagonUI.Fill.ToString());
                data.SetData("Double", pentagonUI.Height);
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

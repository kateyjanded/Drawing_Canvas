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
    /// Interaction logic for rhombus.xaml
    /// </summary>
    public partial class rhombus : UserControl
    {
        public rhombus()
        {
            InitializeComponent();
        }
        private Canvas canv;
        Point mouselocation;

        private bool ismoveable;
        public bool Ismoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }
        bool isdraggable = false;
        public rhombus(rhombus rhom, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.rhombusUI.Height = rhom.rhombusUI.Height;
            this.rhombusUI.Width = rhom.rhombusUI.Width;
            this.rhombusUI.Fill = rhom.rhombusUI.Fill;
            ismoveable = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable==true)
            {
                mouselocation = e.GetPosition(canv);
                double top = mouselocation.Y - (this.ActualHeight / 2);
                double left = mouselocation.X - (this.ActualWidth / 2);

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
        simpleadorner simple;
        AdornerLayer myAdornerLayer;
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (ismoveable == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, rhombusUI.Fill.ToString());
                data.SetData("Double", rhombusUI.Height);
                //data.SetData("Double", rhombusUI.Width);
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

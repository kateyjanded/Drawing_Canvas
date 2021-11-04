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
        simpleadorner simple;
        AdornerLayer myAdornerLayer;

        private bool ismoveable;

        public bool Ismoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }
        bool isdraggable = false;

        public hexagon(hexagon hexa, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.hexagonUI.Height = hexa.hexagonUI.Height;
            this.hexagonUI.Width = hexa.hexagonUI.Width;
            this.hexagonUI.Fill = hexa.hexagonUI.Fill;
            Ismoveable = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable == true)
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
        bool adorneradd = true;
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (Ismoveable == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, hexagonUI.Fill.ToString());
                data.SetData("Double", hexagonUI.Height);
                data.SetData("Double", hexagonUI.Width);
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

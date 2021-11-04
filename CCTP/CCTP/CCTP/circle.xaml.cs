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
    /// Interaction logic for circle.xaml
    /// </summary>
    public partial class circle : UserControl
    {

        public circle()
        {
            InitializeComponent();
            
        }


        private bool isselected;
        public bool Isselected
        {
            get { return isselected; }
            set { isselected = value; }
        }


        public circle(circle c, Canvas canv)
        {
            InitializeComponent();
            this.circleUi.Height = c.circleUi.Height;
            this.circleUi.Width = c.circleUi.Width;
            this.circleUi.Fill = c.circleUi.Fill;
            isMoveable = true;
            canv1 = new Canvas();
            canv1 = canv;
            isselected = false;
        }

        private Canvas canv1;
        private Point Mouselocation;
        private bool ismoveable;

        public bool isMoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }

        public bool isdraggable { get; set; }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable == true)
                {
                    Mouselocation = e.GetPosition(canv1);
                    double left = Mouselocation.X - (this.ActualWidth / 2);
                    double top = Mouselocation.Y - (this.ActualHeight / 2);
                    //Canvas.SetTop(this, top);
                    //Canvas.SetLeft(this, left);

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
           
            if (isMoveable == false)
            {

                DataObject Data = new DataObject();
                Data.SetData(DataFormats.StringFormat, circleUi.Fill.ToString());
                Data.SetData("Double", circleUi.Height);
                Data.SetData("Object", this);
                //Initialize Dragdrop function for object
                DragDrop.DoDragDrop(this, Data, DragDropEffects.Copy);
                
                
            }
            else
            {
                isdraggable = true;
            }
        }
    }
}

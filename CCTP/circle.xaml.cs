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
            //isMoveable = false;
        }

        public circle(circle c, Canvas canv)
        {
            InitializeComponent();
            this.circleUi.Height = c.circleUi.Height;
            this.circleUi.Width = c.circleUi.Height;
            this.circleUi.Fill = c.circleUi.Fill;
            isMoveable = true;
            canv1 = new Canvas();
            canv1 = canv;
        }

        private Canvas canv1;
        private Point Mouselocation;
        private bool ismoveable;

        public bool isMoveable
        {
            get { return ismoveable; }
            set { ismoveable = value; }
        }

        bool isdraggable = false;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isdraggable == true)
            {
                Mouselocation = e.GetPosition(canv1);
                double left = Mouselocation.X - (this.ActualWidth / 2);
                double top = Mouselocation.Y - (this.ActualHeight / 2);
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

            //stores the circle object in an object data
            //circle circleUI = new circle();
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

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Hand);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

    }
}

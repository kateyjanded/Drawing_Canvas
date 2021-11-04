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

        private bool Ismoveable;

        public bool ismoveable
        {
            get { return Ismoveable; }
            set { Ismoveable = value; }
        }
        private bool isdraggable;
        public rectangle(rectangle recta, Canvas can)
        {
            InitializeComponent();
            Canvas canv = new Canvas();
            canv = can;
            this. rectangleUI.Height = recta.rectangleUI.ActualHeight;
            this.rectangleUI.Width = recta.rectangleUI.ActualWidth;
            this.rectangleUI.Fill = recta.rectangleUI.Fill;
            isdraggable = true;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if( ismoveable == false)
            {
                mouselocation = e.GetPosition(canv);
                double top = mouselocation.Y - (rectangleUI.ActualHeight / 2);
                double left = mouselocation.X - (rectangleUI.ActualWidth / 2);
                Canvas.SetTop(this, top);
                Canvas.SetLeft(this, left);
            }
            else
            {
                ismoveable = true;
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
            if (isdraggable == false)
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
                ismoveable = true;
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

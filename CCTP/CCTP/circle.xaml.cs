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

        private Canvas canv;
        Point Mouselocation;
        private bool isdraggable;

        public bool Isdraggable
        {
            get { return isdraggable; }
            set { isdraggable = value; }
        }

        private bool Ismoveable = false;

      

        public circle(circle c, Canvas can)
        {
            InitializeComponent();
            canv = new Canvas();
            canv = can;
            this.cir.Height = c.cir.Height;
            this.cir.Width = c.cir.Width;
            this.cir.Fill = c.cir.Fill;
            Isdraggable = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Ismoveable == true)
            {
                Mouselocation = e.GetPosition(canv);
                double Left = Mouselocation.X - (this.ActualWidth / 2);
                double Top = Mouselocation.Y - (this.ActualHeight / 2);
                Canvas.SetTop(this, Top);
                Canvas.SetLeft(this, Left);
            }
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            Ismoveable = false;
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (isdraggable  == false)
            {
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, cir.Fill.ToString());
                data.SetData("Double", cir.Height);
                data.SetData("Object", this);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy);
            }
            else
            {
                Ismoveable = true;
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
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
        }

       
    }
}

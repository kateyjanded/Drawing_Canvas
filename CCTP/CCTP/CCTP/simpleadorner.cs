using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CCTP
{
    public class simpleadorner: Adorner
    {
        //use thumb for resizing elements
        Thumb topleft, topright, bottomleft, bottomright;
        //visual child collection for adorner
        VisualCollection visualchildren;

        public simpleadorner(UIElement element): base(element)
        {
            visualchildren = new VisualCollection(this);
            //setting thumbs and cursors for the corners
            BuildAdornerCorners(ref topleft, Cursors.SizeNWSE);
            BuildAdornerCorners(ref topright, Cursors.SizeNESW);
            BuildAdornerCorners(ref bottomleft, Cursors.SizeNESW);
            BuildAdornerCorners(ref bottomright, Cursors.SizeNWSE);

            //registering drag delta events for thumb drag movement
            topleft.DragDelta += Topleft_DragDelta;
            topright.DragDelta += Topright_DragDelta;
            bottomleft.DragDelta += Bottomleft_DragDelta;
            bottomright.DragDelta += Bottomright_DragDelta;
        }

        private void Bottomright_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement adornedelement = this.AdornedElement as FrameworkElement;
            Thumb bottomrightcorner = sender as Thumb;
            //setting new height and width after drag
            if (adornedelement != null && bottomrightcorner!= null)
            {
                EnforceSize(adornedelement);
                double oldwidth = adornedelement.Width;
                double oldheight = adornedelement.Height;

                double newWidth = Math.Max(adornedelement.Width + e.HorizontalChange, bottomrightcorner.DesiredSize.Width);
                double newheight = Math.Max(adornedelement.Height + e.VerticalChange, bottomrightcorner.DesiredSize.Height);

                adornedelement.Width = newWidth;
                adornedelement.Height = newheight;
            }
        }

        private void EnforceSize(FrameworkElement element)
        {
            if (element.Width.Equals(Double.NaN))
            {
                element.Width = element.DesiredSize.Width;
            }
            if (element.Height.Equals(Double.NaN))
            {
                element.Height = element.DesiredSize.Height;
            }

            FrameworkElement parent = element.Parent as FrameworkElement;
            if (parent!= null)
            {
                element.MaxHeight = parent.ActualHeight;
                element.MaxWidth = parent.ActualWidth;
            }
        }

        private void Bottomleft_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement adornedelement = this.AdornedElement as FrameworkElement;
            Thumb bottomleftcorner = sender as Thumb;
            if (adornedelement != null && bottomleftcorner != null)
            {
                EnforceSize(adornedelement);

                double oldwidth = adornedelement.Width;
                double oldheight = adornedelement.Height;

                double newWidth = Math.Max(adornedelement.Width - e.HorizontalChange, bottomleftcorner.DesiredSize.Width);
                double newheight = Math.Max(adornedelement.Height + e.VerticalChange, bottomleftcorner.DesiredSize.Height);

                double oldLeft = Canvas.GetLeft(adornedelement);
                double newLeft = oldLeft - (newWidth - oldwidth);
                adornedelement.Width = newWidth;
                Canvas.SetLeft(adornedelement, newLeft);
                adornedelement.Height = newheight;
            }
        }

        private void Topright_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement adornedelement = this.AdornedElement as FrameworkElement;
            Thumb toprightcorner = sender as Thumb;
            if (adornedelement != null && toprightcorner != null)
            {
                EnforceSize(adornedelement);

                double oldwidth = adornedelement.Width;
                double oldheight = adornedelement.Height;

                double newWidth = Math.Max(adornedelement.Width + e.HorizontalChange, toprightcorner.DesiredSize.Width);
                double newheight = Math.Max(adornedelement.Height - e.VerticalChange, toprightcorner.DesiredSize.Height);
                adornedelement.Width = newWidth;
                double oldTop = Canvas.GetTop(adornedelement);
                double newTop = oldTop - (newheight - oldheight);
                adornedelement.Height = newheight;
                Canvas.SetTop(adornedelement, newTop);
                
            }
        }

        private void Topleft_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement adornedelement = this.AdornedElement as FrameworkElement;
            Thumb topleftcorner = sender as Thumb;
            if (adornedelement != null && topleftcorner != null)
            {
                EnforceSize(adornedelement);

                double oldwidth = adornedelement.Width;
                double oldheight = adornedelement.Height;

                double newWidth = Math.Max(adornedelement.Width - e.HorizontalChange, topleftcorner.DesiredSize.Width);
                double newheight = Math.Max(adornedelement.Height - e.VerticalChange, topleftcorner.DesiredSize.Height);

                double oldLeft = Canvas.GetLeft(adornedelement);
                double newLeft = oldLeft - (newWidth - oldwidth);
                adornedelement.Width = newWidth;
                Canvas.SetLeft(adornedelement, newLeft);

                double oldTop = Canvas.GetTop(adornedelement);
                double newTop = oldTop - (newheight - oldheight);
                adornedelement.Height = newheight;
                Canvas.SetTop(adornedelement, newTop);
            }
        }

        private void BuildAdornerCorners(ref Thumb cornerthumb, Cursor customizedcursor)
        {
            if (cornerthumb != null) return;
            {
                cornerthumb = new Thumb() { Cursor = customizedcursor, Height = 10, Width = 10, Opacity = 0.5, Background = new SolidColorBrush(Colors.Blue) };
                visualchildren.Add(cornerthumb);
            }
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            base.ArrangeOverride(finalSize);
            double desiredwidth = AdornedElement.DesiredSize.Width;
            double desiredheight = AdornedElement.DesiredSize.Height;

            double adornerwidth = this.DesiredSize.Width;
            double adornerheight = this.DesiredSize.Height;

            topleft.Arrange(new Rect(-adornerwidth / 2, -adornerheight / 2, adornerwidth, adornerheight));
            topright.Arrange(new Rect(desiredwidth - adornerwidth / 2, -adornerheight / 2, adornerwidth, adornerheight));
            bottomleft.Arrange(new Rect(-adornerwidth / 2, desiredheight - adornerheight / 2, adornerwidth, adornerheight));
            bottomright.Arrange(new Rect(desiredwidth - adornerwidth / 2, desiredheight - adornerheight / 2, adornerwidth, adornerheight));
            return finalSize;
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return visualchildren.Count;
            }
        }
        protected override Visual GetVisualChild(int index)
        {
            return visualchildren[index];
        }
        //to create the blue rectangle onrender
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Rect adornedelementrect = new Rect(this.AdornedElement.DesiredSize);
            Pen renderpen = new Pen(new SolidColorBrush(Colors.Blue), 1.5);

            drawingContext.DrawRectangle(null, renderpen, adornedelementrect);
        }
    }
}

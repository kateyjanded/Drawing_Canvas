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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool isCircleDraggable = false;
        Point Mouselocation;



        private void circleUI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //isCircleDraggable = false;
            //circleUI.ReleaseMouseCapture();
        }

        private void circleUI_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!isCircleDraggable) return;

            //Mouselocation = e.GetPosition(cavtool);
            //double left = Mouselocation.X - (circleUI.ActualWidth / 2);
            //double top = Mouselocation.Y - (circleUI.ActualHeight / 2);
            //Canvas.SetLeft(circleUI, left);
            //Canvas.SetTop(circleUI, top);
            //Mouse.SetCursor(Cursors.No);


        }

        private void circleUI_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            //isCircleDraggable = true;
            //circleUI.CaptureMouse();
        }

        private void drawingcanvas_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent("Object"))
            //{
            //    if (isCircleDraggable == true)
            //    {
                    
            //        e.Effects = DragDropEffects.Copy;
            //    }
                
            //}
        }

        private void drawingcanvas_DragOver(object sender, DragEventArgs e)
        {
           
        }

        private void drawingcanvas_Drop(object sender, DragEventArgs e)
        {
            Canvas _can = (Canvas)sender;
            UIElement _element = (UIElement)e.Data.GetData("Object");

            if (_can != null && _element !=null)
            {
                Canvas _parcanv = (Canvas)VisualTreeHelper.GetParent(_element);

                if (_parcanv != null)
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        circle cui = new circle((circle)_element, drawingcanvas);
                        _can.Children.Add(cui);
                        if (cui.isMoveable)
                        {
                            //_can.Children.Remove(cui);
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double Left = Mouselocation.X - (cui.ActualWidth / 2);
                            double Top = Mouselocation.Y - (cui.ActualHeight / 2);
                            Canvas.SetTop(cui, Top);
                            Canvas.SetLeft(cui, Left);
                            //_can.Children.Add(cui);
                        }
                       
                        
                        //e.Effects = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void drawingcanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }








        //private void movingsphere_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!isCircleDraggable) return;
        //    Mouselocation = e.GetPosition(drawingcanvas);
        //    double Left = Mouselocation.X - (movingsphere.ActualWidth / 2);
        //    double Top = Mouselocation.Y - (movingsphere.ActualHeight / 2);

        //    Canvas.SetTop(movingsphere, Top);
        //    Canvas.SetLeft(movingsphere, Left);

        //}

        //private void movingsphere_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isCircleDraggable = true;
        //    movingsphere.CaptureMouse();
        //}

        //private void movingsphere_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    isCircleDraggable = false;
        //    movingsphere.ReleaseMouseCapture();
        //}
    }
    
}

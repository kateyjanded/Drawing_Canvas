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
        
        //bool isCircleDraggable = false;
        Point Mouselocation;

   
        private void drawingcanvas_DragOver(object sender, DragEventArgs e)
        {
            

        }

        private void drawingcanvas_Drop(object sender, DragEventArgs e)
        {
            Canvas can = (Canvas)sender;
            UIElement element = (UIElement)e.Data.GetData("Object");
            if (can != null && element != null)
            {
                Canvas cave = (Canvas)VisualTreeHelper.GetParent(element);
                if (cave != null)
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        circle cui = new circle((circle)element, drawingcanvas);
                        can.Children.Add(cui);
                        if (cui.Isdraggable == true)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double Left = Mouselocation.X - (cui.ActualWidth/2);
                            double Top = Mouselocation.Y - (cui.ActualHeight / 2);
                            Canvas.SetTop(cui, Top);
                            Canvas.SetLeft(cui, Left);
                        }
                    }
                }
            }
        }
    }
}

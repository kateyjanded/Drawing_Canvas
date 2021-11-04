using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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

        bool isCircleDraggable = true;
        bool iscrossdraggable = true;
        bool isrectangle = true;
        bool istriangle = true;
        bool isline = true;
        bool isrhombus = true;
        bool ispentagon = true;
        bool ishexagon = true;

        Point Mouselocation;
        private void drawingcanvas_Drop(object sender, DragEventArgs e)
        {
            Canvas _can = (Canvas)sender;
            UIElement _element = (UIElement)e.Data.GetData("Object");

            if (_can != null && _element != null)
            {
                //to check the type of element that is about to be dropped
                if (_element.GetType() == typeof(circle))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        circle cui = new circle((circle)_element, drawingcanvas);
                        _can.Children.Add(cui);
                        if (cui.isMoveable)
                        {
                            //gets the position of which circle is to be dropped
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double Left = Mouselocation.X - (cui.ActualWidth / 2);
                            double Top = Mouselocation.Y - (cui.ActualHeight / 2);
                            Canvas.SetTop(cui, Top);
                            Canvas.SetLeft(cui, Left);

                        }
                        //the fill and stroke colour for the instance of the object
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        cui.circleUi.Stroke = renderBrush;

                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        cui.circleUi.Fill = renderfill;
                        this.circle = cui;
                        //this code is for the instance of the circle to be created in the items pane
                        circle crs = new circle((circle)_element, cavpane);
                        if (isCircleDraggable == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 0);
                            Grid.SetRow(crs, 0);
                            isCircleDraggable = false;
                        }
                    }
                }

                if (_element.GetType() == typeof(cross))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        cross cro = new cross((cross)_element, drawingcanvas);
                        _can.Children.Add(cro);
                        if (cro.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (cro.ActualWidth / 2);
                            double top = Mouselocation.Y - (cro.ActualHeight / 2);
                            Canvas.SetTop(cro, top);
                            Canvas.SetLeft(cro, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        cro.CrossUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        cro.CrossUI.Fill = renderfill;
                        this.cross = cro;
                        cross crs = new cross((cross)_element, cavpane);
                        if (iscrossdraggable == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 2);
                            Grid.SetRow(crs, 0);
                            iscrossdraggable = false;
                        }
                    }
                }

                if (_element.GetType() == typeof(rectangle))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        rectangle rec = new rectangle((rectangle)_element, drawingcanvas);
                        _can.Children.Add(rec);
                        if (rec.ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (rec.ActualWidth / 2);
                            double top = Mouselocation.Y - (rec.ActualHeight / 2);
                            Canvas.SetTop(rec, top);
                            Canvas.SetLeft(rec, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        rec.rectangleUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        rec.rectangleUI.Fill = renderfill;
                        this.rectangle = rec;
                        rectangle crs = new rectangle((rectangle)_element, cavpane);
                        if (isrectangle == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 4);
                            Grid.SetRow(crs, 0);
                            isrectangle = false;
                        }
                    }
                }
                if (_element.GetType() == typeof(triangle))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        triangle tan = new triangle((triangle)_element, drawingcanvas);
                        _can.Children.Add(tan);
                        if (tan.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (tan.ActualWidth / 2);
                            double top = Mouselocation.Y - (tan.ActualHeight / 2);
                            Canvas.SetTop(tan, top);
                            Canvas.SetLeft(tan, left);
                        }

                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        tan.triangleUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        tan.triangleUI.Fill = renderfill;
                        this.triangle = tan;
                        triangle crs = new triangle((triangle)_element, cavpane);
                        if (istriangle == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 6);
                            Grid.SetRow(crs, 0);
                            istriangle = false;
                        }
                    }
                }
                if (_element.GetType() == typeof(pentagon))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        pentagon pen = new pentagon((pentagon)_element, drawingcanvas);
                        _can.Children.Add(pen);
                        if (pen.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (pen.ActualWidth / 2);
                            double top = Mouselocation.Y - (pen.ActualHeight / 2);
                            Canvas.SetTop(pen, top);
                            Canvas.SetLeft(pen, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        pen.pentagonUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        pen.pentagonUI.Fill = renderfill;
                        this.pentagon = pen;

                        pentagon crs = new pentagon((pentagon)_element, cavpane);
                        if (ispentagon == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 0);
                            Grid.SetRow(crs, 2);
                            ispentagon = false;
                        }
                    }

                }
                if (_element.GetType() == typeof(hexagon))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        hexagon hex = new hexagon((hexagon)_element, drawingcanvas);
                        _can.Children.Add(hex);
                        if (hex.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (hex.ActualWidth / 2);
                            double top = Mouselocation.Y - (hex.ActualHeight / 2);
                            Canvas.SetTop(hex, top);
                            Canvas.SetLeft(hex, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        hex.hexagonUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        hex.hexagonUI.Fill = renderfill;
                        this.hexagon = hex;
                        hexagon crs = new hexagon((hexagon)_element, cavpane);
                        if (ishexagon == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 2);
                            Grid.SetRow(crs, 2);
                            ishexagon = false;
                        }
                    }
                }
                if (_element.GetType() == typeof(rhombus))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        rhombus rhom = new rhombus((rhombus)_element, drawingcanvas);
                        _can.Children.Add(rhom);
                        if (rhom.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (rhom.ActualWidth / 2);
                            double top = Mouselocation.Y - (rhom.ActualHeight / 2);
                            Canvas.SetTop(rhom, top);
                            Canvas.SetLeft(rhom, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        rhom.rhombusUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        rhom.rhombusUI.Fill = renderfill;
                        this.rhombus = rhom;

                        rhombus crs = new rhombus((rhombus)_element, cavpane);
                        if (isrhombus == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 4);
                            Grid.SetRow(crs, 2);
                            isrhombus = false;
                        }
                    }
                }
                if (_element.GetType() == typeof(line))
                {
                    if (e.Effects.HasFlag(DragDropEffects.Copy))
                    {
                        line lin = new line((line)_element, drawingcanvas);
                        _can.Children.Add(lin);
                        if (lin.Ismoveable)
                        {
                            Mouselocation = e.GetPosition(drawingcanvas);
                            double left = Mouselocation.X - (lin.ActualWidth / 2);
                            double top = Mouselocation.Y - (lin.ActualHeight / 2);
                            Canvas.SetTop(lin, top);
                            Canvas.SetLeft(lin, left);
                        }
                        SolidColorBrush renderBrush = new SolidColorBrush(Colors.Black);
                        lin.lineUI.Stroke = renderBrush;
                        SolidColorBrush renderfill = new SolidColorBrush(Colors.Transparent);
                        lin.lineUI.Fill = renderfill;
                        this.line = lin;

                        line crs = new line((line)_element, cavpane);
                        if (isline == true)
                        {
                            Grid grs = new Grid();
                            setposition.Children.Add(crs);
                            Grid.SetColumn(crs, 6);
                            Grid.SetRow(crs, 2);
                            isline = false;
                        }
                    }
                }
            }   
        }


        AdornerLayer myAdornerLayer;
        bool isselected;
        UIElement selectedelement = null;
        bool isdown;
        double originalleft;
        double originaltop;
        private void drawingcanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isselected)
            {
                isselected = false;
                
                if (selectedelement != null)
                {
                    myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                    myAdornerLayer.Remove(myAdornerLayer.GetAdorners(selectedelement)[0]);
                    selectedelement = null;
                }
            }
            if (e.Source != drawingcanvas)
            {
                isdown = true;
                Point startpoint = e.GetPosition(drawingcanvas);

                selectedelement = e.Source as UIElement;
                originalleft = Canvas.GetLeft(selectedelement);
                originaltop = Canvas.GetTop(selectedelement);

                myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                myAdornerLayer.Add(new simpleadorner(selectedelement));
                isselected = true;
                e.Handled = true;
            }
            else
            {
                if (selectedelement != null)
                {
                    myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                    myAdornerLayer.Remove(myAdornerLayer.GetAdorners(selectedelement)[0]);
                    selectedelement = null;
                }

            }
        }
        circle circle;
        cross cross;
        rectangle rectangle;
        hexagon hexagon;
        pentagon pentagon;
        triangle triangle;
        rhombus rhombus;
        line line;
        private void strkcolor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (selectedelement != null)
            {
                SolidColorBrush renderbrush = new SolidColorBrush(strkcolor.SelectedColor);
                if (selectedelement.GetType() == typeof(circle))
                {
                    circle.circleUi.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(cross))
                {
                    cross.CrossUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(hexagon))
                {
                    hexagon.hexagonUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(rectangle))
                {
                    rectangle.rectangleUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(pentagon))
                {
                    pentagon.pentagonUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(rhombus))
                {
                    rhombus.rhombusUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(triangle))
                {
                    triangle.triangleUI.Stroke = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(line))
                {
                    line.lineUI.Stroke = renderbrush;
                }
            }
        }


        private void cmbselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (drawingcanvas.Children.Count == 0)
            {
                MessageBox.Show("Please don't spoil your mouse key!!!");
            }
            else if (cmbselect.SelectedIndex == 0)
            {
                selectedelement = drawingcanvas.Children[0] as UIElement;
                myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                myAdornerLayer.Add(new simpleadorner(selectedelement));
                cmbselect.Text = null;
            }
            else if (cmbselect.SelectedIndex == 1)
            {
                selectedelement = drawingcanvas.Children[drawingcanvas.Children.Count - 1] as UIElement; 
                myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                myAdornerLayer.Add(new simpleadorner(selectedelement));
                cmbselect.Text = null;
            }
            else if (cmbselect.SelectedIndex == 2)
            {
                selectedelement = drawingcanvas.Children[drawingcanvas.Children.Count / 2] as UIElement; 
                myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                myAdornerLayer.Add(new simpleadorner(selectedelement));
                cmbselect.Text = null;
            }
            else if (cmbselect.SelectedIndex == 3)
            {
                
                foreach (UIElement selectedelement in drawingcanvas.Children)
                {
                    myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                    myAdornerLayer.Add(new simpleadorner(selectedelement));
                    cmbselect.Text = null;
                    isselected = true;
                }   
            }
        }
        private void setposition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                if (e.Source != setposition)
                {
                    isdown = true;
                    Point startpoint = e.GetPosition(setposition);
                    selectedelement = e.Source as UIElement;
                    if (selectedelement.GetType() == typeof(circle))
                    {
                        //selectedelement = e.Source as circle;
                        foreach (circle selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(cross))
                    {
                        foreach (cross selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(rectangle))
                    {
                        foreach (rectangle selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(hexagon))
                    {
                        foreach (hexagon selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(pentagon))
                    {
                        foreach (pentagon selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(rhombus))
                    {
                        foreach (rhombus selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                    else if (selectedelement.GetType() == typeof(line))
                    {
                        foreach (line selectedelement in drawingcanvas.Children)
                        {
                            myAdornerLayer = AdornerLayer.GetAdornerLayer(selectedelement);
                            myAdornerLayer.Add(new simpleadorner(selectedelement));
                            isselected = true;
                        }
                    }
                }
        }

        private void fillcolor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            if (selectedelement != null)
            {
                SolidColorBrush renderbrush = new SolidColorBrush(fillcolor.SelectedColor);
                if (selectedelement.GetType() == typeof(circle))
                {
                    circle.circleUi.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(cross))
                {
                    cross.CrossUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(hexagon))
                {
                    hexagon.hexagonUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(rectangle))
                {
                    rectangle.rectangleUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(pentagon))
                {
                    pentagon.pentagonUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(rhombus))
                {
                    rhombus.rhombusUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(triangle))
                {
                    triangle.triangleUI.Fill = renderbrush;
                }
                else if (selectedelement.GetType() == typeof(line))
                {
                    line.lineUI.Fill = renderbrush;
                }
            }
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "Canvas File(^, canv)|^, canv";
            if (savefiledialog.ShowDialog()== true)
            {
                FileStream fs = File.Open(savefiledialog.FileName, FileMode.Create);
                XamlWriter.Save(drawingcanvas, fs);
                fs.Close();
                //drawingcanvas.Children.Clear();
             

            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Canvas File(^, canv)|^, canv";
            drawingcanvas.Children.Clear();
            if (openfiledialog.ShowDialog()== true)
            {
               FileStream fs = File.OpenRead(openfiledialog.FileName);
               Canvas savedcanvas = (Canvas)XamlReader.Load(fs);
               drawingcanvas.Children.Add(savedcanvas);
               fs.Close();
            }
        }
    }
}
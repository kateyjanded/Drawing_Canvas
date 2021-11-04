using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CCTP
{
    public static class boundshelper
    {
       public static Rect GetBoundsInParentContainer(Control control)
        {
            Vector offset = VisualTreeHelper.GetOffset(control);
            Rect rect = new Rect(offset.X, offset.Y, control.ActualWidth, control.ActualHeight);
            return rect;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace WpfShapes
{
    public class Label : Shape
    {
        protected override Geometry DefiningGeometry
        {
            get { return GetGeometry(); }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            // we will size ourselves to fit the available space
            return constraint;
        }

        public double CornerWidth
        {
            get { return (double)GetValue(CornerWidthProperty); }
            set { SetValue(CornerWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerWidthProperty =
            DependencyProperty.Register("CornerWidth", typeof(double), typeof(Label), new UIPropertyMetadata(10.0, OnCornerWidthChanged));

        
        private static void OnCornerWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Shape)d).InvalidateVisual();
        }


        private Geometry GetGeometry()
        {
            double cornerWidth = CornerWidth;
            //double width = ActualWidth - StrokeThickness;
            double width = ActualWidth - StrokeThickness;
            double height = ActualHeight - StrokeThickness;

            //return Geometry.Parse(String.Format("M {0},{0} h {1} v 100 Z", StrokeThickness / 2.0, width));
            return Geometry.Parse(String.Format("M {0},0 h {1} v {2} h -{1} l -{0},-{0} v -{3} Z", cornerWidth, width-cornerWidth, height, height-(2 * cornerWidth)));
        }
    }
}

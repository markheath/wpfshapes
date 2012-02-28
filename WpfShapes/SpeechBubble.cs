using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace WpfShapes
{
    public class SpeechBubble : Shape
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

        private Geometry GetGeometry()
        {
            double cornerRadius = 10;
            double speechOffset = 30;
            double speechDepth = 20;
            double speechWidth = 20;
            double width = ActualWidth - StrokeThickness;
            double height = ActualHeight - StrokeThickness;
            var g = new StreamGeometry();
            using (var context = g.Open())
            {
                double x0 = StrokeThickness / 2;
                double x1 = x0 + cornerRadius;
                double x2 = width - cornerRadius - x0;
                double x3 = x2 + cornerRadius;

                double x4 = x0 + speechOffset;
                double x5 = x4 + speechWidth;

                double y0 = StrokeThickness / 2;
                double y1 = y0 + cornerRadius;
                double y2 = height - speechDepth - (cornerRadius * 2);
                double y3 = y2 + cornerRadius;
                double y4 = y3 + speechDepth;
                context.BeginFigure(new Point(x1, y0), true, true);
                context.LineTo(new Point(x2,y0), true, true);
                context.ArcTo(new Point(x3,y1), new Size(cornerRadius, cornerRadius), 90, false, SweepDirection.Clockwise, true, true);
                context.LineTo(new Point(x3,y2), true, true);
                context.ArcTo(new Point(x2,y3), new Size(cornerRadius, cornerRadius), 90, false, SweepDirection.Clockwise, true, true);
                context.LineTo(new Point(x5,y3), true, true);
                context.LineTo(new Point(x4,y4), true, true);
                context.LineTo(new Point(x4,y3), true, true);
                context.LineTo(new Point(x1, y3), true, true);
                context.ArcTo(new Point(x0, y2), new Size(cornerRadius, cornerRadius), 90, false, SweepDirection.Clockwise, true, true);
                context.LineTo(new Point(x0, y1), true, true);
                context.ArcTo(new Point(x1, y0), new Size(cornerRadius, cornerRadius), 90, false, SweepDirection.Clockwise, true, true);
            }
            g.Freeze();
            return g;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfShapes
{
    public class Chevron : Shape
    {
        public Chevron()
        {
            this.Stretch = Stretch.Fill;
            this.StrokeLineJoin = PenLineJoin.Round;
        }

        protected override Geometry DefiningGeometry
        {
            get { return GetGeometry(); }
        }

        private Geometry GetGeometry()
        {
            return Geometry.Parse("M 0, 40 l 20, -40 l 20, 40 h -10 l -10, -20 l -10, 20 Z");
        }
    }
}

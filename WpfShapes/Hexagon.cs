using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WpfShapes
{
    public class Hexagon : Shape
    {
        public Hexagon() :base()
        {
            this.Stretch = System.Windows.Media.Stretch.Fill;
        }
        protected override Geometry DefiningGeometry
        {
            get { return GetGeometry(); }
        }

        private Geometry GetGeometry()
        {
            double sideLength = 100;
            double x = Math.Sqrt(sideLength * sideLength / 2);
            return Geometry.Parse(String.Format("M {0},0 h {1} l {0},{0} l -{0},{0} h -{1} l -{0},-{0} Z", x, sideLength));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WpfShapes
{
    public class RoundedSidesRectangle : Shape
    {
        protected override Geometry DefiningGeometry
        {
            get { return GetGeometry(); }
        }

        private Geometry GetGeometry()
        {
            return Geometry.Parse("M 20,10 h 100 a 100,100,45,0,1,0,100 h -100 a 100,100,-45,0,1,0,-100 Z");
        }
    }
}

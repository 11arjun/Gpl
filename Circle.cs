using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace component1
{
    class Circle : Shape
    {
        int radius;

        public Circle() : base()
        {

        }

        public Circle(Color color, bool fill, int x, int y, int radius) : base(color, fill,x, y)
        {
            this.radius = radius;
        }

        public override void set(Color color, bool fill, params int[] list)
        {
            base.set(color,fill, list[0], list[1]);
            this.radius = list[2];
        }

        public override void draw(Graphics g)
        {
            if (fill)
            {

                SolidBrush b = new SolidBrush(color);
                g.FillEllipse(b, x, y, radius * 2, radius * 2);
                
            }
            else {
                Pen p = new Pen(color, 2);
                g.DrawEllipse(p, x, y, radius * 2, radius * 2);
            }
            
        }

        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.radius;
        }
    }

}

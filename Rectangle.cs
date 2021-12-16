using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace component1
{
    class Rectangle : Shape
    {
        int width, height;

        public Rectangle() : base()
        {

        }

        public Rectangle(Color color, bool fill,int x, int y, int width, int height) : base(color,fill, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void set(Color color, bool fill,params int[] list)
        {
            base.set(color, fill, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        public override void draw(Graphics g)
        {
            if (fill)
            {
                SolidBrush b = new SolidBrush(color);
                g.FillRectangle(b, x, y, width, height);
            }
            else {
                Pen p = new Pen(color, 2);
                g.DrawRectangle(p, x, y, width, height);
            }     
        }

        public override double calcArea()
        {
            return width * height;
        }

        public override double calcPerimeter()
        {
            return 2 * (width + height);
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.width + " " + this.height;
        }
    }
}

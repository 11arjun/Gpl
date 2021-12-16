using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace component1
{
    abstract  class Shape:IShapes
    {
        protected Color color;
        protected bool fill;
        protected int x, y;

        public Shape()
        {
            color = Color.Black;
            x = y = 100;
        }

        
        public Shape(Color color, bool fill, int x, int y)
        {
            this.color = color;
            this.fill = fill;
            this.x = x;
            this.y = y;
        }

        public abstract void draw(Graphics g);
        public abstract double calcArea();
        public abstract double calcPerimeter();

        public virtual void set(Color color, bool fill, params int[] list)
        {
            this.color = color;
            this.fill = fill;
            this.x = list[0];
            this.y = list[1];
        }
        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace component1
{
    interface  IShapes
    {
        void set(Color c, bool fill,params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();
    }
}

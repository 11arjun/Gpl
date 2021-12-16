using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace component1
{
    class Parser
    {
        private static int x = 0, y = 0;
        private static Color color = Color.Black;
        private static bool fill;

        public static void clear()
        {
            x = 0;
            y = 0;
            color = Color.Black;
            fill = false;
        }
        public static void parse(string cmd, Graphics g)
        {
            ShapeFactory factory = new ShapeFactory();
            try
            {
                string[] args = cmd.Split(" ", 2);
                string command = args[0];
                string parameters = "";
                if (args.Length > 1)
                {
                    parameters = args[1];
                }
                switch (command.ToLower())
                {
                    case "":
                        break;
                    case "circle":
                        int radius = int.Parse(parameters.Trim());
                        Shape circle = factory.getShape("circle");
                        circle.set(color, fill,x, y, radius);
                        circle.draw(g);
                        break;
                    case "rectangle":
                        int width = int.Parse(parameters.Split(",")[0].Trim());
                        int height = int.Parse(parameters.Split(",")[1].Trim());
                        Shape rectangle = factory.getShape("rectangle");
                        rectangle.set(color, fill,x, y, width, height);
                        rectangle.draw(g);
                        break;
                    case "triangle":
                        int x2 = int.Parse(parameters.Split(',')[0].Trim());
                        int y2 = int.Parse(parameters.Split(',')[1].Trim());
                        int x3 = int.Parse(parameters.Split(',')[2].Trim());
                        int y3 = int.Parse(parameters.Split(',')[3].Trim());
                        Shape triangle = factory.getShape("triangle");
                        triangle.set(color, fill,x, y, x2, y2, x3, y3);
                        triangle.draw(g);
                        break;
                    case "moveto":
                        x = int.Parse(parameters.Split(",")[0].Trim());
                        y = int.Parse(parameters.Split(",")[1].Trim());
                        break;
                    case "color":
                        try
                        {
                            if (parameters.Split(",").Length == 1)
                                color = Color.FromName(parameters.Trim());
                            else if (parameters.Split(",").Length == 3)
                            {
                                int red = int.Parse(parameters.Split(",")[0].Trim());
                                int green = int.Parse(parameters.Split(",")[1].Trim());
                                int blue = int.Parse(parameters.Split(",")[2].Trim());
                                color = Color.FromArgb(255, red, green, blue);
                            }
                            else if (parameters.Split(",").Length == 4)
                            {
                                int alpha = int.Parse(parameters.Split(",")[0].Trim());
                                int red = int.Parse(parameters.Split(",")[1].Trim());
                                int green = int.Parse(parameters.Split(",")[2].Trim());
                                int blue = int.Parse(parameters.Split(",")[3].Trim());
                                color = Color.FromArgb(alpha, red, green, blue);
                            }
                            else
                            {
                                MessageBox.Show("Invalid Color Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            

                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid Color Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "fill":
                        {
                            fill = bool.Parse(parameters.Split(",")[0].Trim());
                            break;
                        }
                        
                    case "clear":
                        {
                            g.Clear(Color.Gray);
                            break;
                        }
                    default:
                        MessageBox.Show("Unknown Command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Invalid argument type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

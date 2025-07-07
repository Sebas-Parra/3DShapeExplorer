using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_SHAPE_EXPLORER.Utils
{
    public class FloodFillDFS
    {
        public static List<Point> floodFill(PictureBox canvas, int x0, int y0, Bitmap bmp)
        {
            List<Point> points = new List<Point>();

            if (x0 < 0 || y0 < 0 || x0 >= bmp.Width || y0 >= bmp.Height)
                return points;

            Color oldColor = bmp.GetPixel(x0, y0);
            Color newColor = Config.Instance.FillColor;

            if (oldColor.ToArgb() == newColor.ToArgb())
                return points;

            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x0, y0));

            while (stack.Count > 0)
            {
                Point currentPoint = stack.Pop();
                int x = currentPoint.X;
                int y = currentPoint.Y;

                if (x < 0 || y < 0 || x >= bmp.Width || y >= bmp.Height)
                    continue;

                if (bmp.GetPixel(x, y).ToArgb() != oldColor.ToArgb())
                    continue;

                bmp.SetPixel(x, y, newColor);
                points.Add(currentPoint);

                if (Config.Instance.AnimationDelay != 0)
                {
                    canvas.Image = bmp;
                    canvas.Refresh();
                    Task.Delay(Config.Instance.AnimationDelay);
                }

                stack.Push(new Point(x + 1, y));
                stack.Push(new Point(x - 1, y));
                stack.Push(new Point(x, y + 1));
                stack.Push(new Point(x, y - 1));
            }

            canvas.Image = bmp;
            return points;
        }
    }
}

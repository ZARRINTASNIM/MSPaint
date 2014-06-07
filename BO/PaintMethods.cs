using System;
using System.Drawing;
using Entity;


namespace BO
{
   public class PaintMethods
    {
       DrawingEntities va = new DrawingEntities();

       public void lineDrawing(String colorve, Graphics g, int xa, int ya, int xb, int yb)
        {
            int dx = xb - xa, dy = yb - ya, steps;
            float xIncrement, yIncrement, x = xa, y = ya;

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);

            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            Bitmap bmp = new Bitmap(1, 1);
            bmp.SetPixel(0, 0, Color.FromName(colorve));

            g.DrawImage(bmp, round(x), round(y));

            for (int k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;

                g.DrawImage(bmp, round(x), round(y));
            }

        }
            

        public int round(float a)
        {
            return (int)(a + .5);
        }



        public void circleDrawing(String colorve ,Graphics g, int xAxis1 , int yAxis1,int xAxis2,int yAxis2)
        {
            Bitmap bmpM = new Bitmap(1, 1);
            bmpM.SetPixel(0, 0, Color.FromName(colorve));

            int McbX = xAxis1;
            int McbY = yAxis1;
            int McbR = (int)Math.Sqrt((xAxis1 - xAxis2) * (xAxis1 - xAxis2) + (yAxis1 - yAxis2) * (yAxis1 - yAxis2));

            int Mx = 0, My = (int)McbR, Mp = (int)(1 - McbR);

            while (Mx <= My)
            {
                if (Mp < 0)
                {
                    Mp = Mp + 2 * Mx + 3;
                }
                else
                {
                    Mp = Mp + 2 * (Mx - My) + 5;
                    My--;
                }
                Mx++;
                //upper lower
                g.DrawImage(bmpM, (McbX + Mx), (McbY + My));
                g.DrawImage(bmpM, (McbX - Mx), (McbY + My));
                g.DrawImage(bmpM, (McbX + Mx), (McbY - My));
                g.DrawImage(bmpM, (McbX - Mx), (McbY - My));
                //side
                g.DrawImage(bmpM, (McbX + My), (McbY + Mx));
                g.DrawImage(bmpM, (McbX - My), (McbY + Mx));
                g.DrawImage(bmpM, (McbX + My), (McbY - Mx));
                g.DrawImage(bmpM, (McbX - My), (McbY - Mx));
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picbox
{
    class Class1
    {
        public static Bitmap DrawKoords(Bitmap bmp, PictureBox  pctBox, Pen WowPen)
        {
            Graphics lines = Graphics.FromImage(bmp);
            lines.DrawLine(WowPen, 0, pctBox.Height / 2, pctBox.Width, pctBox.Height / 2);
            lines.DrawLine(WowPen, pctBox.Width / 2, 0, pctBox.Width / 2, pctBox.Height);
            return bmp;
        }

        
        // Рисуем синус
        public static Bitmap DrawSin(Bitmap bmp, PictureBox pctBox, Pen WowPen, double ugol)
        {
            Graphics Dsin = Graphics.FromImage(bmp);
            int x = pctBox.Width;
            int y = pctBox.Height / 2;
            PointF[] ptf = new PointF[x];
            for (int i = 0; i < x; i++)
            {
                ptf[i].X = i + 5;
                ptf[i].Y = (float)(((y / 2) * (1 - Math.Sin(i * 8 * Math.PI / (x - 1)))) + (y % 50) );
            }
            Dsin.DrawLines(WowPen, ptf);

            Pen PPen= new Pen(Color.Red);
            int temp = 8;
            if (ugol == 0) temp = 0;
            

            //Рисуем угол
            Dsin.DrawLine(PPen, 0, (float)((y) - Math.Sin(ugol) * (y / 2) - temp),
               pctBox.Width, (float)((y) - Math.Sin(ugol) * (y / 2)) - temp);
            return bmp;

        }
        // Рисуем косинус
        public static Bitmap DrawCos(Bitmap bmp, PictureBox pctBox, Pen WowPen, double ugol)
        {
            Graphics Dcos = Graphics.FromImage(bmp);
            int x = pctBox.Width;
            int y = pctBox.Height / 2;
            PointF[] ptf = new PointF[x];
            for (int i = 0; i < x; i++)
            {
                ptf[i].X = i;
                ptf[i].Y = (float)(((y / 2) * (1 - Math.Cos(i * 8 * Math.PI / (x - 1)))) + (y % 50));
            }
            Dcos.DrawLines(WowPen, ptf);

            Pen PPen = new Pen(Color.Red);
            int temp = 8;
            if ((ugol == Math.PI / 2) || (ugol == -Math.PI / 2)) temp = 0;
            Dcos.DrawLine(PPen, 0, (float)((y) - Math.Cos(ugol) * (y / 2) - temp),
              pctBox.Width, (float)((y) - Math.Cos(ugol) * (y / 2)) - temp);

            return bmp;

        }
        // Рисуем тангенс
        public static Bitmap DrawTg(Bitmap bmp, PictureBox pctBox, Pen WowPen, double ugol)
        {
            Graphics Dtg = Graphics.FromImage(bmp);
            int x = pctBox.Width;
            int y = pctBox.Height / 2;
            PointF[] ptf = new PointF[x];
            for (int i = 0; i < x; i++)
            {
                ptf[i].X = i + 5;
                ptf[i].Y = (float)((((y / 4) * (1 - Math.Tan(i * 8 * Math.PI / (x - 1)))) + (y % 50)) + 25);
            }
            Dtg.DrawLines(WowPen, ptf);

            double temp;
            temp = ugol * 180 / Math.PI;
            Pen PPen = new Pen(Color.Red);
            // Проверочка на углы, в которых тангенс не определен
            if ((temp != 90) || (temp != -90))
            {

                if (((temp % 90) != 0) || (((temp / 90) % 2) == 0))
                {
                    Dtg.DrawLine(PPen, 0, (float)((y) - Math.Tan(ugol) * (y / 2)),
                      pctBox.Width, (float)((y) - Math.Tan(ugol) * (y / 2)));
                }
            }

            return bmp;
        }
        // Рисуем котангенс
        public static Bitmap DrawCtg(Bitmap bmp, PictureBox pctBox, Pen WowPen, double ugol)
        {
            Graphics Dctg = Graphics.FromImage(bmp);
            int x = pctBox.Width;
            int y = pctBox.Height / 2;
            PointF[] ptf = new PointF[x];
            for (int i = 0; i < x; i++)
            {
                ptf[i].X = i;
                ptf[i].Y = (float)((((y / 2) * 1 / (1 - Math.Tan((i + 20) * 8 * Math.PI / (x - 1)))) + (y % 50)) + 30);
            }
            Dctg.DrawLines(WowPen, ptf);

            double temp;
            temp = ugol * 180 / Math.PI;
            Pen PPen = new Pen(Color.Red);

            if ((temp % 90) != 0)
            {
                Dctg.DrawLine(PPen, 0, (float)((y) - 1 / Math.Tan(ugol) * (y / 2)),
                          pctBox.Width, (float)((y) - 1 / Math.Tan(ugol) * (y / 2)));
            }
            else
            {
                if (((temp / 90) % 2) != 0)
                {
                    Dctg.DrawLine(PPen, 0, (float)((y) - 1 / Math.Tan(ugol) * (y / 2)),
                          pctBox.Width, (float)((y) - 1 / Math.Tan(ugol) * (y / 2)));
                }

            }
            return bmp;

        }
    }
}

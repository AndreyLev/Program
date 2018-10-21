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


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) return;
                else
                {
                    if (e.KeyChar == '-')
                    {

                        if ((textBox1.TextLength > 0) || (textBox1.Text.IndexOf('-') != -1))
                        {
                            e.Handled = true;
                            return;
                        }
                        return;
                    }
                    else
                        if (e.KeyChar == '\b') return;
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        button1_Click(sender, e);
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                    {
                        e.Handled = true;
                        return;
                    }

                }
            }
            catch(Exception b)
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    double temp;
                    double alfa = Convert.ToDouble(textBox1.Text);
                    if (radioButton1.Checked)
                    {
                        alfa *= Math.PI / 180;
                        label2.Text = "alfa = " + alfa.ToString();

                    }
                    if (radioButton2.Checked)
                    {
                        alfa *= 180 / Math.PI;
                        label2.Text = "alfa = " + alfa.ToString();
                        alfa *= Math.PI / 180;
                    }



                    // Создаем битмапы для всех picture box'ov
                    Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Bitmap sin = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                    Bitmap cos = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                    Bitmap tg = new Bitmap(pictureBox4.Width, pictureBox4.Height);
                    Bitmap ctg = new Bitmap(pictureBox5.Width, pictureBox5.Height);
                    // Черная ручка
                    Pen MyPen = new Pen(Color.Black);
                    Pen RPen = new Pen(Color.Red);
                    bmp = Class1.DrawKoords(bmp, pictureBox1, MyPen);
                    sin = Class1.DrawKoords(sin, pictureBox2, MyPen);
                    cos = Class1.DrawKoords(cos, pictureBox3, MyPen);
                    tg = Class1.DrawKoords(tg, pictureBox4, MyPen);
                    ctg = Class1.DrawKoords(ctg, pictureBox5, MyPen);

                    // Рисуем единичную окружность + угол на ней
                    Graphics Pbmp = Graphics.FromImage(bmp);
                    Pbmp.DrawEllipse(MyPen, new Rectangle(10, 20, bmp.Width - 20, bmp.Height - 40));

                    Pbmp.DrawLine(RPen, (pictureBox1.Width - 5) / 2, (pictureBox1.Height) / 2,
                    (int)((pictureBox1.Width - 5) / 2 + Math.Cos(alfa) * ((pictureBox1.Width - 20) / 2)),
                    (int)(pictureBox1.Height / 2 - Math.Sin(alfa) * ((pictureBox1.Height - 40) / 2)));


                    sin = Class1.DrawSin(sin, pictureBox2, MyPen, alfa);
                    cos = Class1.DrawCos(cos, pictureBox3, MyPen, alfa);
                    tg = Class1.DrawTg(tg, pictureBox4, MyPen, alfa);
                    ctg = Class1.DrawCtg(ctg, pictureBox5, MyPen, alfa);
                    pictureBox1.Image = bmp;
                    pictureBox2.Image = sin;
                    pictureBox3.Image = cos;
                    pictureBox4.Image = tg;
                    pictureBox5.Image = ctg;

                    // Указываем значения тригонометрических функций
                    label3.Text = "Sin = " + Convert.ToString(Math.Sin(alfa));
                    label4.Text = "Cos = " + Convert.ToString(Math.Cos(alfa));
                    label5.Text = "Tg = " + Convert.ToString(Math.Tan(alfa));
                    label6.Text = "Ctg = " + Convert.ToString(1 / Math.Tan(alfa));


                }
            }
            catch (Exception b)
            {
                MessageBox.Show("Введите значение угла");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

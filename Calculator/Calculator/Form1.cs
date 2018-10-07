using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Объявляю первую, вторую и результирующую дроби
        Drob firstDrob = new Drob();
        Drob secondDrob = new Drob();
        Drob result = new Drob();
        string currentoper = "";
        Control lastF;
   
        private void Tr()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
        }

        private void DopF()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            
        }

        private void Enb()
        {
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;  
            
        }

        public Form1()
        {
            InitializeComponent();
            Enb();
            button14.Enabled = false;
            lastF = textBox1;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Обрабатываем клик
            try
            {
                if ((firstDrob.Ch == 0) && (firstDrob.Chisl == 0) && (textBox1.Text != "")
                    && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    // Запоминание первой дроби
                    firstDrob.SetDrob(ch: Convert.ToInt32(textBox1.Text.Trim()),
                        chisl: Convert.ToInt32(textBox2.Text),
                        znam: Convert.ToInt32(textBox3.Text));

                    // Очистка текстбоксов

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    currentoper = button12.Text;
                    
                    Enb();
                    DopF();
                    Tr();
                    button14.Enabled = false;
                    textBox1.Focus();
                }
            }
            catch (Exception InputE)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    secondDrob.SetDrob(ch: Convert.ToInt32(textBox1.Text),
                        chisl: Convert.ToInt32(textBox2.Text),
                        znam: Convert.ToInt32(textBox3.Text));

                    // Запоминание операции
                    switch(currentoper)
                    {
                        case "+":
                            result = firstDrob.Plus(secondDrob);
                            break;
                        case "-":
                            result = firstDrob.Minus(secondDrob);
                            break;
                        case "/":
                            result = firstDrob.Division(secondDrob);
                            break;
                        case "*":
                            result = firstDrob.Multiplication(secondDrob);
                            break;
                        default: break;
                    }
                    // Очистка информации об операции
                    currentoper = "";
                    //Вывод результата
                    textBox1.Text = result.Ch.ToString();
                    textBox2.Text = result.Chisl.ToString();
                    textBox3.Text = result.Znam.ToString();
                    //Чистим информацию о дробях
                    firstDrob.CleanDrob();
                    secondDrob.CleanDrob();
                    result.CleanDrob();

                    

                    textBox1.Focus();
                    button14.Enabled = false;
                }
            }
            catch(Exception b)
            {
                MessageBox.Show("Ошибка");
            }

            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                else
                {
                    if (e.KeyChar == '-')
                    {
                        if ( (textBox1.TextLength > 0) || (textBox1.Text.IndexOf('-') != -1) )
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (e.KeyChar == '\b')
                        {
                            return;
                        }
       
                        if (e.KeyChar == (char)Keys.Enter)
                        {
                            textBox1.Select(textBox1.Text.Length, 0);
                            textBox2.Focus();
                            lastF = textBox2;
                            
                            
                            
                        }
                        else
                        {
                            e.Handled = true;
                            return;

                        }
                    }
                }
                
            }
            catch(Exception b)
            {
                MessageBox.Show("Ошибка");
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Обрабатываем клик
            try
            {
                if ((firstDrob.Ch == 0) && (firstDrob.Chisl == 0) && (textBox1.Text != "")
                    && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    // Запоминание первой дроби
                    firstDrob.SetDrob(ch: Convert.ToInt32(textBox1.Text),
                        chisl: Convert.ToInt32(textBox2.Text),
                        znam: Convert.ToInt32(textBox3.Text));

                    // Очистка текстбоксов

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    currentoper = button10.Text;
                    
                    Enb();
                    DopF();
                    Tr();
                    button14.Enabled = false;
                    textBox1.Focus();
                }
                
            }
            catch(Exception InputE)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Чистим все и вся
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            firstDrob.CleanDrob();
            secondDrob.CleanDrob();
            result.CleanDrob();
            currentoper = "";

            Enb();
            DopF();
            Tr();
            button14.Enabled = false;
            textBox1.Focus();

           


        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Обрабатываем клик
            try
            {
                if ((firstDrob.Ch == 0) && (firstDrob.Chisl == 0) && (textBox1.Text != "")
                    && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    // Запоминание первой дроби
                    firstDrob.SetDrob(ch: Convert.ToInt32(textBox1.Text),
                        chisl: Convert.ToInt32(textBox2.Text),
                        znam: Convert.ToInt32(textBox3.Text));

                    // Очистка текстбоксов

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    currentoper = button11.Text;
                    
                    Enb();
                    DopF();
                    Tr();
                    button14.Enabled = false;
                    textBox1.Focus();
                }
            }
            catch (Exception InputE)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Обрабатываем клик
            try
            {
                if ((firstDrob.Ch == 0) && (firstDrob.Chisl == 0) && (textBox1.Text != "")
                    && (textBox2.Text != "") && (textBox3.Text != ""))
                {
                    // Запоминание первой дроби
                    firstDrob.SetDrob(ch: Convert.ToInt32(textBox1.Text),
                        chisl: Convert.ToInt32(textBox2.Text),
                        znam: Convert.ToInt32(textBox3.Text));

                    // Очистка текстбоксов

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    currentoper = button13.Text;
                    
                    Enb();
                    DopF();
                    Tr();
                    button14.Enabled = false;
                    textBox1.Focus();
                }
            }
            catch (Exception InputE)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                else
                {
                    if (e.KeyChar == '-')
                    {
                        if ((textBox2.TextLength > 0) || (textBox1.Text.IndexOf('-') != -1))
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                    else
                    {
                        if (e.KeyChar == '\b')
                        {
                            return;
                        }

                        if (e.KeyChar == (char)Keys.Enter)
                        {
                            textBox2.Select(textBox1.Text.Length, 0);
                            textBox3.Focus();
                            lastF = textBox3;
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }

            }
            catch (Exception b)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                {
                    return;
                }
                else
                {
                    if (e.KeyChar == '-')
                    {

                        e.Handled = true;
                        return;

                    }
                    else
                    {
                        if (e.KeyChar == '\b')
                        {
                            return;
                        }

                        if (e.KeyChar == (char)Keys.Enter)
                        {
                            textBox3.Select(textBox1.Text.Length, 0);
                            if (currentoper != "")
                            {
                                button14_Click(sender, e);
                                Enb();
                                
                            }
                            else
                            {
                                MessageBox.Show("Выберите операцию");
                                textBox1.Enabled = false;
                                textBox2.Enabled = false;
                                textBox3.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button3.Enabled = false;
                                button4.Enabled = false;
                                button5.Enabled = false;
                                button6.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = false;
                                button9.Enabled = false;
                                button16.Enabled = false;
                                button17.Enabled = false;

                                button10.Focus();

                            }
                        }
                        else
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }

            }
            catch (Exception b)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '1';
                lastF.Focus();
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '2';
                lastF.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '3';
                lastF.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '4';
                lastF.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '5';
                lastF.Focus();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '6';
                lastF.Focus();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '7';
                lastF.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '8';
                lastF.Focus();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '9';
                lastF.Focus();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
                lastF.Text += '0';
                lastF.Focus();
                
            }
        }
        // Установка фокуса на текстбоксы с помощью мыши
        private void textBox1_Enter(object sender, EventArgs e)
        {
            lastF = (Control)sender;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            lastF = (Control)sender;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            lastF = (Control)sender;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if ((lastF != button10) && (lastF != button11) && (lastF != button12) && (lastF != button13))
            {
               
                    if (lastF.Text.Length != 0)
                    {
                        lastF.Text = lastF.Text.Substring(0, lastF.Text.Length - 1);
                        lastF.Focus();
                    }
                
               
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (((textBox1.Text.Length != 0) && (textBox2.Text.Length > 0)) || ((textBox1.Text.Length == 0)
                    && (textBox2.Text.Length > 0)))
            {
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                
                

            }
            if (currentoper != "")
            {
                button14.Enabled = true;
                Enb();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 Box = new AboutBox1();
            Box.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Drob
    {
          int ch;
         int chisl;
        int znam;

    public int Ch
        {
            get { return this.ch; }
        }

        public int Chisl
        {
            get { return this.chisl; }
        }

        public int Znam
        {
            get { return this.znam; }
        }

        public Drob(int ch = 0, int chisl = 0, int znam = 1)
        {
            this.ch = ch;
            this.chisl = chisl;
            this.znam = znam;
        }

        public void SetDrob(int ch, int chisl, int znam)
        {
            this.ch = ch;
            this.chisl = chisl;
            this.znam = znam;
        }



        // Введение целой части
        public void Dtrans()
        {
            if (this.ch != 0)
            {
                this.chisl = this.znam * this.ch + this.chisl;
                this.ch = 0;
            }
        }
        //Сложение
        public Drob Plus(Drob secondDrob)
        {
            this.Dtrans();
            secondDrob.Dtrans();

            Drob result = new Drob();

            result.chisl = (this.chisl * secondDrob.znam) + (this.znam * secondDrob.chisl);
            result.znam = this.znam * secondDrob.znam;

            result.ReTrans();

            return result;
        }
        //Вычитание
        public Drob Minus(Drob secondDrob)
        {
            this.Dtrans();
            secondDrob.Dtrans();

            Drob result = new Drob();

            result.chisl = (this.chisl * secondDrob.znam) - (this.znam * secondDrob.chisl);
            result.znam = this.znam * secondDrob.znam;

            result.ReTrans();

            return result;

        }
        //Умножение
        public Drob Multiplication(Drob secondDrob)
        {
            this.Dtrans();
            secondDrob.Dtrans();

            Drob result = new Drob();

            result.chisl = this.chisl * secondDrob.chisl;
            result.znam = this.znam * secondDrob.znam;

            return result;
        }
        //Деление
        public Drob Division(Drob secondDrob)
        {
            this.Dtrans();
            secondDrob.Dtrans();

            Drob result = new Drob();

            result.chisl = this.chisl * secondDrob.znam;
            result.znam = this.znam * secondDrob.chisl;

            return result;
        }

        // Выделяем целую часть
       private void ReTrans()
        {
            try
            {
                this.ch = this.chisl / this.znam;
                this.chisl = this.chisl % this.znam;
            }
            catch (DivideByZeroException e)
            {
                this.znam = 1;
                this.ReTrans();
            }
        }

        // Очищаем информацию о дробях
        public void CleanDrob()
        {
            this.ch = 0;
            this.chisl = 0;
            this.znam = 1;
        }

       
    }   
}

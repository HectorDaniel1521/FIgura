using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApplication2
{
    abstract class Figura:IComparable
    {
        protected int X;
        protected int Y;
        protected Pen pluma;
        protected int ancho;
        protected int largo;
        protected Color color;
        protected SolidBrush brocha;

        public Figura(int x, int y )
        {
            X = x;
            Y = y;
            brocha = new SolidBrush(Color.Red);
            pluma = new Pen(Color.Black, 100);
             
                
            Random rnd = new Random();
            ancho = rnd.Next(50,80);
            largo = ancho;
        }

        public abstract void Draw(Form f);

        public int CompareTo(object obj)
        {

            return this.largo.CompareTo(((Figura)obj).largo);
        }
    }


    class Rectangulo:Figura
    {
        public Rectangulo(int x, int y ):base(x,y)
    	{
        } 

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, this.X, this.Y, ancho, largo);
            g.FillRectangle(brocha, this.X, this.Y, ancho, largo);
        }

    }

    class Circulo : Figura
    {
        public Circulo(int x, int y) : base(x, y)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, this.X, this.Y, ancho, largo);
            g.FillEllipse(brocha, this.X, this.Y, ancho, largo);
        }

    }

}

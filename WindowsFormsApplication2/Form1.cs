using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        enum TipoFigura  {Rectangulo, Circulo};

        private TipoFigura figura_actual; 
        private List<Figura> figura;
        

        public Form1()
        {
            figura_actual = TipoFigura.Circulo;
           
            figura = new List<Figura>();
            InitializeComponent();
            circuloToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                
                contextMenuStrip1.Show(this, e.X,e.Y);
            }
            else if (MouseButtons.Left == e.Button)
            {
                if (figura_actual == TipoFigura.Circulo)
                    {
                    Circulo c = new Circulo(e.X, e.Y);
                    c.Draw(this);
                    figura.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y);
                    r.Draw(this);
                    figura.Add(r);
                }
            }
          

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Polimorfismo
            foreach (Figura r in figura)
                r.Draw(this);
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rectanguloToolStripMenuItem.Checked = true;
            this.circuloToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Circulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figura.Sort();
            figura.Reverse();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            figura.Clear();
            this.Invalidate();
        }
    }
}

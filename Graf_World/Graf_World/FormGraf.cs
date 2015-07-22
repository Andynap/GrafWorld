using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf_World
{
    public partial class Form1 : Form
    {
        private Bitmap graphBitMap;
        private List<Rectangle> listRec = new List<Rectangle>();//list čtverců s názvem listRec
        private Graphics g;
        private Font Fontik = new Font(new FontFamily("Arial"), 15F, FontStyle.Regular);

        public Form1()
        {
            InitializeComponent();
        }

       
        //pokud není navrátová hodnota píšu void, pokud je nevratová hodnota místo voidu píšu konkrétní datový typ např. string, int
        private void drawListRec(List<Rectangle> _listRec)
        {
            foreach (Rectangle index in _listRec) //index určuje která položka z listu se vykreslí
            {
                g.FillRectangle(Brushes.BlueViolet, index);
                g.DrawRectangle(Pens.Black, index);
            }
            if (_listRec.Count >= 2)
            {
                string answer = _listRec.ElementAt(0).IntersectsWith(_listRec.ElementAt(1)).ToString();
                g.DrawString(answer, Fontik, Brushes.Black, this.graphBitMap.Width - (g.MeasureString(answer, this.Fontik).Width) - 10, 0);
            }
         }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.graphBitMap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);

  
            g = Graphics.FromImage(this.graphBitMap); //zde si načtu bit mapu do g
            Rectangle rec0 = new Rectangle((int)numericStartX.Value, (int)numericStartY.Value, 50, 50); //(int) zajistí aby se nam datový, ořezal na int, pokud to lze
            listRec.Add(rec0);
            //ručně přidání do listu

            Rectangle rec2 = new Rectangle(20, 30, 35, 35);
            listRec.Add(rec2);

            Rectangle rec1 = new Rectangle(20, 30, 20, 20);
            listRec.Add(rec1);
                       
            this.numericStartX.Maximum = this.graphBitMap.Width-rec0.Width;
            this.numericStartY.Maximum = this.graphBitMap.Height - rec0.Height;

            drawListRec(listRec); //vykreslovací funkce
                                    
            this.pictureBox1.BackgroundImage = graphBitMap;
        }

        private void numericStartX_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(this.pictureBox1.BackColor);

            Rectangle docasna = listRec.ElementAt(0);
            docasna.X = (int)numericStartX.Value;
            listRec[0] = docasna;
            drawListRec(listRec);

            pictureBox1.Refresh();
        }

        private void numericStartY_ValueChanged(object sender, EventArgs e)
        {
            g.Clear(this.pictureBox1.BackColor);
            Rectangle docasna = listRec.ElementAt(0);
            docasna.Y = (int)numericStartY.Value;
            listRec[0] = docasna;
            drawListRec(listRec);

            pictureBox1.Refresh();
        }
    }
}

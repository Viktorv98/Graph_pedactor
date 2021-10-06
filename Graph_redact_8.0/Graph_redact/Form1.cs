using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_redact
{
    public partial class Form1 : Form
    {
        private Controller controller;
        public float XX = 0, YY = 0;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            controller.SetOutPort(pictureBox1.CreateGraphics());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.SetItemType(TypeFigure.Line);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.SetItemType(TypeFigure.Rect);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.SetItemType(TypeFigure.Ellipse);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            controller.SetItemType(TypeFigure.Group);
            controller.AddGroup();
            controller.SetItemType(TypeFigure.None);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                controller.MouseDwnCtrl(e.X, e.Y);
            }
            else
            controller.MouseDwn(e.X, e.Y);
            XX = e.X; YY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            controller.MouseMove(e.X, e.Y, e.X - XX, e.Y - YY);
            XX = e.X; YY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            controller.MouseUp(e.X, e.Y);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) 
        {
            controller.Repaint();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controller.SetItemType(TypeFigure.Graph);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            controller.UnGroup();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       // bool toolStripButton3Info = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            Pen Green = new Pen(Color.Green, 1);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int countHorizontal = pictureBox1.Width / 40;
            int countVertical = pictureBox1.Height / 40;
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                for (int i = 0; i < countHorizontal; i++)
                {
                    for (int j = 0; j < countVertical; j++)
                    {
                        g.DrawRectangle(Green, i * 40, j * 40, 40, 40);
                    }
                }
            }
            
            //pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            //Pen Blue = new Pen(Color.Blue,4);
            //using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            //{
            //    g.Clear(Color.White);
            //    g.DrawEllipse(Blue,2,2,46,46);
            //}
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.Hand;
            //this.Cursor = Cursors.UpArrow;
            Pen Green = new Pen(Color.Green, 1);
            Pen Blue = new Pen(Color.Blue, 2);
            int x = e.X;
            int y = e.Y;
            
            int countX = x / 40;
            int countY = y / 40;
            label1.Text = countX.ToString();
            label2.Text = countY.ToString();
            int countHorizontal = pictureBox1.Width / 40;
            int countVertical = pictureBox1.Height / 40;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                if (toolStripButton3.Checked == true)
                for (int i = 0; i < countHorizontal; i++)
                {
                    for (int j = 0; j < countVertical; j++)
                    {
                        g.DrawRectangle(Green, i * 40, j * 40, 40, 40);
                    }
                }
                if (toolStripButton1.Checked == true)
                g.DrawEllipse(Blue, countX * 40+1, countY * 40+1, 39, 39);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            bool toolStripButton3Info = toolStripButton3.Checked;
            toolStripButton3.Checked = !toolStripButton3Info;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bool toolStripButton1Info = toolStripButton1.Checked;
            toolStripButton1.Checked = !toolStripButton1Info;
        }
    }
}

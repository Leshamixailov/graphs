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

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Pen Blue = new Pen(Color.Blue,4);
            using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            {
                g.Clear(Color.White);
                g.DrawEllipse(Blue,2,2,46,46);
            }
        }
    }
}

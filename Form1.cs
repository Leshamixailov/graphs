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
        int count = 0;
        public List<int> list = new List<int>();
        // bool toolStripButton3Info = true;

        public Item[,] Items = new Item[30, 15];
        private void Form1_Load(object sender, EventArgs e)
        {
            Pen Green = new Pen(Color.Green, 1);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int countHorizontal = pictureBox1.Width / 40;
            int countVertical = pictureBox1.Height / 40;
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        // Item Item = new Item();
                        Items[i, j]= new Item();
                        Items[i, j].x = i;
                        Items[i, j].y = j;
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
            Pen Red = new Pen(Color.Red, 2);
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            int x = e.X;
            int y = e.Y;
            
            int countX = x / 40;
            int countY = y / 40;
            if (Items[countX, countY].number != 0)
            label2.Text = Items[countX, countY].number.ToString();
            else
            label2.Text ="";
            //label2.Text = countY.ToString();
            int countHorizontal = pictureBox1.Width / 40;
            int countVertical = pictureBox1.Height / 40;
            label3.Text = Items[countX, countY].Id;

            label6.Text = Items[countX, countY].x.ToString();
            label7.Text = Items[countX, countY].y.ToString();
            label8.Text=Items[countX, countY].svyaz.Count.ToString();
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
                {
                     g.DrawEllipse(Red, countX * 40+1, countY * 40+1, 39, 39);
                    
                }
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (Items[i, j].Id == "Вершина")
                        {
                            g.DrawEllipse(Blue, i * 40 + 1, j * 40 + 1, 39, 39);
                        }
                        if (Items[i, j].Id == "#" && toolStripButton3.Checked)
                        {
                            g.FillRectangle(yellow, i * 40 + 1, j * 40 + 1,39,39);
                        }

                    }
                }
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

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            int countX = x / 40;
            int countY = y / 40;
            if (toolStripButton1.Checked)
            {

                if (Items[countX, countY].Id == "Пусто")
                {
                count++;
                Items[countX, countY].Id = "Вершина";
                Items[countX, countY].number = count;
                list.Add(count);
                if(countX <29)
                Items[countX+1, countY].Id = "#";
                if (countX > 0)
                Items[countX-1, countY].Id = "#";
                if (countY < 14)
                Items[countX, countY+1].Id = "#";
                if (countY > 0)
                Items[countX, countY-1].Id = "#";

                if (countX < 29 && countY < 14)
                    Items[countX + 1, countY+1].Id = "#";
                if (countX > 0 && countY > 0)
                    Items[countX - 1, countY-1].Id = "#";
                if (countY < 14 && countX > 0)
                    Items[countX-1, countY + 1].Id = "#";
                if (countX < 29 && countY > 0)
                    Items[countX+1, countY - 1].Id = "#";
                }
            }
            if (toolStripButton2.Checked)
            {

                if (Items[countX, countY].Id == "Вершина")
                {
                    
                    Form2 form2 = new Form2(list, countX, countY);
                    form2.ShowDialog(this);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bool toolStripButton2Info = toolStripButton2.Checked;
            toolStripButton2.Checked = !toolStripButton2Info;
        }
    }
}

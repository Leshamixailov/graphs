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
        public int start = 0;
       
        Image image;
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
                        
                        Items[i, j]= new Item();
                        Items[i, j].x = i;
                        Items[i, j].y = j;
                    }
                }
            }
            image = new Bitmap("flag-map-marker-1_icon-icons.com_56727.png");
        }
        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Cursor.Current = Cursors.Hand;
            //this.Cursor = Cursors.UpArrow;
            Pen Green = new Pen(Color.Green, 1);
            Pen Blue = new Pen(Color.Blue, 2);
            Pen Indigo = new Pen(Color.Indigo, 2);
            Pen Red = new Pen(Color.Red, 2);
            Font font = new Font("Segoe UI",10,FontStyle.Regular);
            Font font1 = new Font("Segoe UI", 12, FontStyle.Regular);
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
                            if (!Items[i, j].startPosition)
                            { g.DrawEllipse(Blue, i * 40 + 1, j * 40 + 1, 39, 39);}
                            else
                            {
                                g.DrawEllipse(Indigo, i * 40 + 1, j * 40 + 1, 39, 39);
                                g.DrawImage(image,i * 40 + 7, j * 40 + 5, 30, 30);
                            }
                            
                            g.DrawString(Items[i, j].number.ToString(),font1,Brushes.Blue, i * 40 + 10, j * 40 + 10);
                        }
                        if (Items[i, j].Id == "#" && toolStripButton3.Checked)
                        {
                            g.FillRectangle(yellow, i * 40 + 1, j * 40 + 1,39,39);
                        }
                        
                    }
                }
                Pen Blue1 = new Pen(Color.Blue,3);


                //Blue1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                       
                        if (Items[i, j].svyaz.Count > 0)
                        {
                            foreach (var s in Items[i, j].from)
                            {
                                
                                g.DrawLine(Blue, Items[i, j].to, s);
                                g.DrawEllipse(Red, s.X-2, s.Y-2, 5, 5);

                            }

                        }
                        if (Items[i, j].TextLocation.Count > 0)
                        {
                            int count = 0;
                            foreach (var s in Items[i, j].TextLocation)
                            {
                                g.DrawString("("+Items[i, j].number.ToString()+"-"+ Items[i, j].svyaz[count]+")" + Items[i, j].ves[count].ToString(), font, Brushes.Black, s.X,s.Y);
                                count++;
                            }
                               
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
            if (toolStripButton2.Checked)
                toolStripButton2.Checked = false;
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
            if(toolStripButton1.Checked)
            toolStripButton1.Checked = false;
            bool toolStripButton2Info = toolStripButton2.Checked;
            toolStripButton2.Checked = !toolStripButton2Info;
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (list.Count > 0)
            {
                toolStripButton4.Enabled = false;
                Form3 form3 = new Form3(list);
                form3.ShowDialog(this);
                MessageBox.Show("Стартовой вершиной выбрана вершина " + start.ToString());

                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        
                        if (Items[i, j].number == start)
                        {
                            Items[i, j].startPosition = true;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Добавьте хотябы одну вершину");
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
            List<Item> Elements = new List<Item>();
            List<int> marked = new List<int>();
            List<int> NextCheck = new List<int>();
            List<int> NextCheck1 = new List<int>();
            //marked.AddRange(list);
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Items[i, j].number != 0)
                    {
                        Elements.Add(Items[i, j]);
                    }
                   
                }
            }
            foreach (var a in Elements)
            {
                if (a.startPosition == true)
                {
                   
                    a.bestСondition = 0;
                    int i = 0;
                    foreach (var b in a.svyaz)
                    {
                        foreach (var c in Elements)
                        {
                            if (c.number == b)
                            {
                                if (a.bestСondition + a.ves[i] < c.bestСondition)
                                {
                                    c.bestСondition = a.bestСondition + a.ves[i];
                                    c.way = a.number;
                                }
                            }
                        }
                        i++;
                        NextCheck.Add(b);
                    }
                    marked.Add(a.number);
                }
            }

            while(NextCheck1.Count!=0)
            {
                
                foreach (var d in NextCheck)
                {
                    foreach (var a in Elements)
                    {
                        if (a.number == d)
                        {
                            int i = 0;
                            foreach (var b in a.svyaz)
                            {
                                foreach (var c in Elements)
                                {
                                    if (c.number == b)
                                    {
                                        if (a.bestСondition + a.ves[i] < c.bestСondition)
                                        {
                                            c.bestСondition = a.bestСondition + a.ves[i];
                                            c.way = a.number;
                                        }
                                    }
                                }
                                i++;
                                foreach (var r in marked)
                                    if (a.number != r)
                                        NextCheck1.Add(b);
                            }

                            marked.Add(a.number);

                            //NextCheck.Remove(a.number);
                        }

                    }

                }
                
                NextCheck.Clear();
                NextCheck.AddRange(NextCheck1);
            }
            int stop= 5;
            string way = stop.ToString() + "-";

            MessageBox.Show(Elements[5].way.ToString());
            while (stop!=0)
            {
                
                foreach (var a in Elements)
                {
                    if (a.number == Elements[stop].way)
                    {
                        way += Elements[stop].way.ToString() + "-";
                      
                        stop = Elements[Elements[stop].way].way;
                    }
                }
            }
             MessageBox.Show(way);
        }
    }
}

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
    public partial class Form2 : Form
    {
        List<int> list;
        int x1;
        int y1;
        public Form2(List<int> s,int x,int y)
        {
            InitializeComponent();
            list = s;
            x1 = x;
            y1 = y;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            var Parent = (Form1)this.Owner;
            foreach (int i in list)
            {
                if (i!=Parent.Items[x1,y1].number)
                comboBox1.Items.Add(i.ToString());
            }
                             
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k ;
            int.TryParse(textBox1.Text, out k);
            if (k != 0 && comboBox1.SelectedIndex>-1)
            {
                var Parent = (Form1)this.Owner;

                Parent.Items[x1, y1].svyaz.Add(Convert.ToInt32(comboBox1.SelectedItem.ToString()));


                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (Parent.Items[i, j].number == Convert.ToInt32(comboBox1.SelectedItem.ToString()))
                            Parent.Items[x1, y1].from.Add(new Point(Parent.Items[i, j].x * 40 + 20, Parent.Items[i, j].y * 40 + 20));
                    }
                }
               
                Parent.Items[x1, y1].to = new Point(x1 * 40 + 20, y1 * 40 + 20);
                //x =Xa+R*Xb\(1+R) , где R отношение отрезков в результате деления
                //y =Ya+R*Yb\(1+R) , где R отношение отрезков в результате деления
                int Xmedium = (Parent.Items[x1, y1].from.Last().X/3 + Parent.Items[x1, y1].to.X) *3/4;
                int Ymedium = (Parent.Items[x1, y1].from.Last().Y/3 + Parent.Items[x1, y1].to.Y) *3/4;
                Parent.Items[x1, y1].TextLocation.Add(new Point(Xmedium, Ymedium))  ; 
                Parent.Items[x1, y1].ves.Add(int.Parse(textBox1.Text));
                //Parent.Items[x1, y1].bestСondition.Add(99999999);
                //MessageBox.Show(Parent.Items[x1, y1].to.X.ToString()+" "+ Parent.Items[x1, y1].from.X.ToString());
                //Parent.Close();
                Parent.dataGridView1.Rows.Add(Parent.Items[x1, y1].number, Convert.ToInt32(comboBox1.SelectedItem.ToString()), Parent.Items[x1, y1].ves.Last());
            }
            else
                MessageBox.Show("Неверный параметр вес или не выбрана вершина");
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

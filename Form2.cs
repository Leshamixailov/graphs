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
            foreach (int i in list)
            {
                comboBox1.Items.Add(i.ToString());
            }
           
                
            
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Parent = (Form1)this.Owner;

            Parent.Items[x1, y1].svyaz.Add(Convert.ToInt32(comboBox1.SelectedItem.ToString()));
            //Parent.Close();
        }
    }
}

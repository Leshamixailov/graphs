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
    public partial class Form3 : Form
    { 
        public Form3(List<int> s)
        {
            InitializeComponent();
            list = s;
        }
          List<int> list;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            var Parent = (Form1)this.Owner;
            if (comboBox1.SelectedIndex > -1)
            {
                Parent.start = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Не выбрана вершина");
            }
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            

            Form1 form1 = new Form1();
            var Parent = (Form1)this.Owner;
            foreach (int i in list)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }
    }
}

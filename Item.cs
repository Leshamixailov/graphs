using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    public class Item
    {
        public string Id = "Пусто";
        public bool startPosition = false;//{ get; set; }
        public int x = 0;
        public int y = 0;
        public int number = 0;
        public List<int>  ves = new List<int>();
        public List<int> svyaz = new List<int>();
        public Point to = new Point(0,0);
        public List<Point> from = new List<Point>();
        public List<Point> TextLocation = new List<Point>();
    }
}

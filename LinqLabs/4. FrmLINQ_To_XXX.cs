using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            categoriesTableAdapter1.Fill(nwDataSet1.Categories);
            productsTableAdapter1.Fill(nwDataSet1.Products);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<IGrouping<string, int>>
                q = from n in nums
                        //group n by (n % 2 );
                    group n by (n % 2 == 0 ? "偶數" : "奇數");

            dataGridView1.DataSource = q.ToList();
            //=======================================

            foreach (var group in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(group.Key.ToString());
                foreach (var item in group)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                        //group n by (n % 2 );
                    group n by n % 2 == 0 ? "偶數" : "奇數" into g
                    select new { Mykey = g.Key, Mycont = g.Count(), Myavg = g.Average(), Mygroup = g };
            dataGridView1.DataSource = q.ToList();
            //=======================================

            foreach (var group in q)
            {
                string s = $"{group.Mykey}{group.Mycont}";
                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.Mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            var q = from n in nums
                        //group n by (n % 2 );
                    group n by Mykey(n) into g
                    select new { Mykey = g.Key, Mycount = g.Count(), Myavg = g.Average(), Mygroup = g };
            dataGridView1.DataSource = q.ToList();
            //=======================================
            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].XValueMember = "Mykey";
            this.chart1.Series[0].YValueMembers = "Mycount";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


            foreach (var group in q)
            {
                string s = $"{group.Mykey}{group.Mycount}";
                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.Mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private string Mykey(int a)
        {
            if (a < 5)
                return "小";
            else if (a < 10)
                return "中";
            else
                return "大";


        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();


            var q = from c in files

                    group c by c.Extension into aa

                    orderby aa.Count() descending

                    select new { aa.Key, Mycount = aa.Count() };

            dataGridView1.DataSource = q.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    let s = f.Extension
                    where s == ".exe"
                    select f;
            MessageBox.Show("" + q.Count());

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }


        private void button15_Click(object sender, EventArgs e)
        {
            int[] num1 = { 1, 2, 3, 4, 545, 222 };
            int[] num2 = { 1, 2, 3, 4, 52, 11 };
            var q = num1.Intersect(num2);
            q = num2.Distinct();//刪除重複

            bool a = num1.Any(n => n > 100);//大於100的
            num1.Contains(2);//包含
            int qq = num1.First();//第一筆
            qq = num1.ElementAt(2000);//超出界線爆掉
            qq = num1.ElementAtOrDefault(300);//超出界線傳回0
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Products
                    group n by n.CategoryID into g
                    select new { CategoryID = g.Key, AvgUnitPrice = g.Average(p => p.UnitPrice) };
            dataGridView1.DataSource = q.ToList();

            //join
            var qq = from c in nwDataSet1.Categories
                     join f in nwDataSet1.Products on c.CategoryID equals f.CategoryID
                     group f by c.CategoryName into g
                     select new
                     {
                         CategoryID = g.Key,
                         Avgprice = g.Average(p => p.UnitPrice)
                     };
            dataGridView2.DataSource = qq.ToList();

            //var q = from n in nums
            //            //group n by (n % 2 );
            //        group n by Mykey(n) into g
            //        select new { Mykey = g.Key, Mycount = g.Count(), Myavg = g.Average(), Mygroup = g };
            //dataGridView1.DataSource = q.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int[] nums = { 1,2,3, 4, 5,6,7,8,9};
            //int[] TT = { 123, 456, 78910 };
            //nums.Sp;
        }
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from n in files
                    group n by 分類方法((int)n.Length) into pk
                    select new { KY = pk.Key, MY = pk };
            foreach (var x in q)
            {
                string s = $"{x.KY}";
                TreeNode P = this.treeView1.Nodes.Add(s);// (x.Key.ToString());
                foreach (var o in x.MY)
                {
                    P.Nodes.Add(o.ToString());
                }
            }
        }
        string 分類方法(int p)
        {
            if (p > 1000)
                return "大";
            else return "小";
        }
        string 價格分類(decimal p)
        {
            if (p < 30)
                return "低價位";
            else if (p < 50)
                return "中價位";
            else return "高價位";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            treeView1.Nodes.Clear();
            var q = from n in nwDataSet1.Products.AsEnumerable()
                    group n by 價格分類(n.UnitPrice) into pk
                    select new { KY = pk.Key, 產品名稱 = pk.Select(n => n.ProductName) };
            foreach (var x in q)
            {
                string s = $"{x.KY}";
                TreeNode P = this.treeView1.Nodes.Add(s);// (x.Key.ToString());
                foreach (var o in x.產品名稱)
                {
                    P.Nodes.Add(o.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from n in files
                    group n by n.CreationTime.Year into pk
                    select new { KY = pk.Key, MY = pk };
            foreach (var x in q)
            {
                string s = $"{x.KY}";
                TreeNode P = this.treeView1.Nodes.Add(s);// (x.Key.ToString());
                foreach (var o in x.MY)
                {
                    P.Nodes.Add(o.ToString());
                }
            }
        }



        private void button15_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Orders
                    group n by n.OrderDate.Year into pk
                    select new { KY = pk.Key, 年筆數 = pk.Count() };
            this.dataGridView2.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Orders.AsEnumerable()
                    group n by n.OrderDate.Year into pk
                    select new { KY = pk.Key, 月份 = pk, };
            this.dataGridView2.DataSource = q.ToList();
            foreach (var x in q)
            {
                string s = $"{x.KY}";
                TreeNode 年分
                    = this.treeView1.Nodes.Add(s);// (x.Key.ToString());
                foreach (var o in x.月份.Select(n => n.OrderDate.Month).Distinct())
                {
                    TreeNode 月份 = 年分.Nodes.Add(o.ToString());
                    foreach (var G in x.月份.Select(n => n.CustomerID).Distinct())
                    {
                        月份.Nodes.Add(G.ToString());
                    }
                }
            }
        }
            private void button2_Click(object sender, EventArgs e)
            {
            var q = dbcontext.Order_Details.Select(n => (n.UnitPrice * n.Quantity * 1 - (int)n.Discount)).Sum();
            MessageBox.Show($"{q:c2}".ToString());

              }
            NorthwindEntities dbcontext = new NorthwindEntities();
            private void button9_Click(object sender, EventArgs e)
            {
            var q = from n in this.dbcontext.Products.AsEnumerable()

                    group n by n.Category.CategoryName into g
                    select new { 類別名稱 = g.Key, 最高單價 = g.Max(Q => Q.UnitPrice) };
            dataGridView1.DataSource = q.OrderByDescending(n => n.最高單價).Take(5).ToList();
        }

            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
            //List<Point> point = new {12,123 };
            var q = from p in this.dbcontext.Order_Details
                    group p by p.OrderID into g
                    select new { CategoryID = g.Key, 銷售業績 = g.Sum(p => p.UnitPrice * p.Quantity * 1 - (int)p.Discount) };
            dataGridView2.DataSource = q.OrderByDescending(n => n.銷售業績).Take(5).ToList();

             }

            private void button3_Click(object sender, EventArgs e)
            {
            var q = from n in this.dbcontext.Products
                    where n.UnitPrice > 300
                    select n;
            if (q.Count() == 0)
                MessageBox.Show("沒有價格超過300");
            else
                MessageBox.Show("有喔");
             }
        
    }
}


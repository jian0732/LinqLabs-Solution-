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
            productsTableAdapter1.Fill(nwDataSet1.Products);
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            categoriesTableAdapter1.Fill(nwDataSet1.Categories);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            IEnumerable<IGrouping<string, System.IO.FileInfo>> q = from n in files
                                                                   group n by n.Length > 1000 ? "大" : "小";
            dataGridView1.DataSource = q.ToList();

            //==================
            foreach (var 大小 in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(大小.Key.ToString());
                foreach (var item in 大小)
                {
                    x.Nodes.Add(item.ToString());
                }



            }


        }
        private string MyPrice(decimal a)
        {
            if (a < 30)
                return "低";
            else if (a < 50)
                return "中";
            else
                return "高價";
        }
        private void button8_Click(object sender, EventArgs e)
        {

            var q = from n in dbcontext.Products.AsEnumerable()
                    group n by MyPrice(Convert.ToDecimal(n.UnitPrice)) into g
                    select new { Mykey = g.Key, 產品名稱 = g.Select(n => n.ProductName) };
            dataGridView1.DataSource = q.ToList();
            //var q = from n in nwDataSet1.Products
            //        group n by MyPrice((int)n.UnitPrice) into g
            //        select new { Mykey=g.Key, Mycount = g.Count(),Mygroup=g };

            //dataGridView1.DataSource = q.ToList();
            //===================================
            foreach (var cc in q)
            {
                string s = $"{cc.Mykey}";
                TreeNode x = this.treeView1.Nodes.Add(s);
                foreach (var item in cc.產品名稱)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

        }












        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            IEnumerable<IGrouping<string, System.IO.FileInfo>> q = from n in files
                                                                   group n by n.CreationTime.Year < 2020 ? "2020前資料" : "2020後資料";
            dataGridView1.DataSource = q.ToList();

            //==================
            foreach (var 大小 in q)
            {
                TreeNode x = this.treeView1.Nodes.Add(大小.Key.ToString());
                foreach (var item in 大小)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Orders
                    group n by n.OrderDate.Year into g
                    select new { Order = g.Key, Count = g.Count(), Mygroup = g };
            dataGridView1.DataSource = q.ToList();

            //================
            foreach (var group in q)
            {
                string s = $"{group.Order}({group.Count})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var item in group.Mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Orders

                    group n by n.OrderDate.Year into g

                    orderby g.Key
                    select new { 年 = g.Key, Count = g.Count() };
            //=====
            var m = from n in nwDataSet1.Orders

                    group n by n.OrderDate.Month into g

                    orderby g.Key
                    select new { 年 = g.Key, Count = g.Count() };
            dataGridView2.DataSource = m.ToList();
            dataGridView1.DataSource = q.ToList();
        }
        int _position = -1;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _position = e.RowIndex;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (_position < 0)
                return;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = dbcontext.Order_Details.Select(n => n.UnitPrice * n.Quantity * (1 - (int)n.Discount)).Sum();
            //(((double)UnitPrice*Quantity*(1-Discount)))
            MessageBox.Show($"{q:C2}");






        }
        NorthwindEntities dbcontext = new NorthwindEntities();
        private void button9_Click(object sender, EventArgs e)
        {
            var q = from n in nwDataSet1.Categories join p in nwDataSet1.Products on n.CategoryID equals p.CategoryID

                    orderby p.UnitPrice descending

                    select new { n.CategoryName, p.UnitPrice};
                    
                      

                 
            dataGridView1.DataSource = q.Take(5).ToList();

            //var q = from n in dbcontext.Products.AsEnumerable()
            //        group n by MyPrice(Convert.ToDecimal(n.UnitPrice)) into g
            //        select new { Mykey = g.Key, 產品名稱 = g.Select(n => n.ProductName) };
            //dataGridView1.DataSource = q.ToList();






            //var q = dbcontext.Categories.OrderByDescending(n => n.CategoryName).Take(5);



            //dataGridView1.DataSource = q.ToList();


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from n in dbcontext.Order_Details.AsEnumerable()
                    group n by n.OrderID into g
                    
                    select new { g.Key, 總金額 = g.Select(n => n.Quantity * n.UnitPrice * (1 - (int)n.Discount)).Sum() };
            dataGridView1.DataSource = q.OrderByDescending(n => n.總金額).Take(5).ToList();
            //dbcontext.Order_Details.Select(n => n.UnitPrice * n.Quantity * (1 - (int)n.Discount)).Sum().Equals.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from n in dbcontext.Products
                    where n.UnitPrice > 300
                    select n;
            
            if (q.Count()==0)
            {
                MessageBox.Show("沒有");
            }


        }
    }
}

using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLinq_To_Entity : Form
    {
        public FrmLinq_To_Entity()
        {
            InitializeComponent();
            dbcontext.Database.Log= Console.WriteLine;
        }
        NorthwindEntities dbcontext = new NorthwindEntities();
        private void button1_Click(object sender, EventArgs e)
        {        
            var q = from a in dbcontext.Products
                    where a.UnitPrice > 30
                    select a;
            dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = this.dbcontext.Categories.First().Products.ToList();
            //MessageBox.Show(dbcontext.Products.First().Categories.CategoryName);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var q = from n in dbcontext.Products
                    orderby n.UnitsInStock , n.ProductID
                    select n;
            dataGridView1.DataSource = q.ToList();
            //===================
            var c = from n in dbcontext.Products.OrderByDescending(p => p.UnitsInStock)
                    .ThenBy(n => n.UnitPrice)
                    select n;
            dataGridView2.DataSource = c.ToList();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //var q = from n in dbcontext.Products.AsEnumerable()
            //        group n by n.Categories.CategoryName into g
            //        select new { Cate = g.Key, 平均分 =$"{ g.Average(s => s.UnitPrice):c2}" };
            //dataGridView1.DataSource = q.ToList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var q = from o in dbcontext.Orders
                    group o by o.OrderDate.Value.Year into g
                    select new { g.Key, count = g.Count() };
            dataGridView1.DataSource = q.ToList();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Product pro = new Product { ProductName = "text", Discontinued = false };
            this.dbcontext.Products.Add(pro);

            dbcontext.SaveChanges();

        }

        private void button53_Click(object sender, EventArgs e)
        {
            Product pro = new Product { ProductName = "text", Discontinued = false };
            this.dbcontext.Products.Add(pro);

            dbcontext.SaveChanges();
        }
    }
}

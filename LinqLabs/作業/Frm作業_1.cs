using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();

            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        int i;
        int y;
        private void button13_Click(object sender, EventArgs e)
        {
            
             i +=Convert.ToInt32(textBox1.Text);
            int aa = Convert.ToInt32(textBox1.Text);
            
            var q = (from n in nwDataSet1.Products

                     select n).Take(i);

            
            dataGridView2.DataSource = q.Skip(i-aa).ToList();
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)
            //i += (Convert)textBox1.Text
            //this.productsTableAdapter1.Fill(nwDataSet1.Products);
            //var q = 

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            this.dataGridView1.DataSource = files;
            this.dataGridView1.DataSource = files;
            var q = from aa in files
                    where aa.Extension == ".log"
                    select aa;
            dataGridView1.DataSource = q.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						
            var q = from n in students_scores

                    select n;
            dataGridView1.DataSource = q.ToList();
            // 找出 前面三個 的學員所有科目成績				

            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	
            var a = from c in students_scores
                    where c.Name != "bbb"
                    select c;
            dataGridView1.DataSource = a.ToList();

            // 數學不及格 ... 是誰 
                       #endregion



        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();
            this.dataGridView1.DataSource = files;
            var q = from aa in files
                    where aa.CreationTime.Year == 2019
                    select aa;
            dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;
            var q = from aa in files
                    where aa.Length > 10000
                    select aa;
            dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            dataGridView1.DataSource = nwDataSet1.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            var q = from a in nwDataSet1.Orders
                    where a.OrderDate.Year == Convert.ToInt32(comboBox1.Text)
                    select a;

            var c = from b in nwDataSet1.Order_Details
                    join s in q
                    on b.OrderID equals s.OrderID
                    select b;
            dataGridView1.DataSource = q.ToList();
            dataGridView2.DataSource = c.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            i -= Convert.ToInt32(textBox1.Text);
            int aa = Convert.ToInt32(textBox1.Text);
            var q = (from n in nwDataSet1.Products

                     select n).Take(i);
            dataGridView2.DataSource = q.Skip(i - aa).ToList();
        }
    }
}

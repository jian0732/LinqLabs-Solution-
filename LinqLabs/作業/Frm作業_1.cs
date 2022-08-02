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
            this.order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "陳兆倫", Class = "CS_101", Chi = 88, Eng = 87, Math = 70, Gender = "Male" },
                                            new Student{ Name = "陳苡錚", Class = "CS_102", Chi = 80, Eng = 90, Math = 76, Gender = "Female" },
                                            new Student{ Name = "洪暐婷", Class = "CS_101", Chi = 90, Eng = 100, Math = 88, Gender = "Female" },
                                            new Student{ Name = "游曉雯", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "李紘毅", Class = "放牛班", Chi = 5, Eng = 2, Math = 0, Gender = "Male" },
                                            new Student{ Name = "林恆佑", Class = "放牛班", Chi = 8, Eng = 15, Math = 2, Gender = "Male" },
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
        int io;
        int pp;
        private void button13_Click(object sender, EventArgs e)
        {
            int tb1 = Convert.ToInt32(textBox1.Text);
            var q = from p in nwDataSet1.Products
                    select p;
            dataGridView2.DataSource = q.Skip(io).Take(tb1).ToList();
            io += tb1;
            pp = io - tb1;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;
            var q = from p in files where p.Extension ==".log" select p;
            //this.dataGridView1.DataSource = q.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            // 
            // 共幾個 學員成績 ?						
            var q = from n in students_scores
                    select n;
            dataGridView1.DataSource = q.ToList();
            // 找出 前面三個 的學員所有科目成績
            var w = (from n in students_scores
                     select n).Take(3);
            dataGridView1.DataSource = w.ToList();

            // 找出 後面兩個 的學員所有科目成績					
            var r = (from n in students_scores
                     select n);

            // 找出 Name 'aaa','bbb','ccc' 的學成績			

            var t = (from n in students_scores
                     where n.Name == "陳兆倫" | n.Name == "陳苡錚" | n.Name == "洪暐婷"
                     select n);
            dataGridView1.DataSource = t.ToList();
            // 找出學員 'bbb' 的成績	                          
            var QQ = (from n in students_scores
                      where n.Name == "陳苡錚"
                      select n);
            dataGridView1.DataSource = t.ToList();
            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	
            var QP = (from n in students_scores
                      where n.Name != "陳苡錚"
                      select n);
            dataGridView1.DataSource = QP.ToList();

            // 數學不及格 ... 是誰 

            var PP = (from n in students_scores
                      where n.Math < 60
                      select n);
            dataGridView1.DataSource = PP.ToList();
    }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();


            var q = from p in files where p.CreationTime.Year == 2019 select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from p in files where p.Length > 8000 orderby p.Length descending select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(nwDataSet1.Orders);
            var q = from p in nwDataSet1.Orders where !p.IsShippedDateNull() select p;
            //this.dataGridView1.DataSource = nwDataSet1.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from p in nwDataSet1.Orders
                    where p.OrderDate.Year.ToString() == comboBox1.Text && !p.IsShippedDateNull()
                    select p;
            var y = from j in nwDataSet1.Order_Details
                    join s in q
                    on j.OrderID equals s.OrderID
                    select j;

            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = y.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int tb1 = Convert.ToInt32(textBox1.Text);
            var q = from p in nwDataSet1.Products
                    select p;
            dataGridView2.DataSource = q.Skip(pp - tb1).Take(tb1).ToList();
            io = pp;
            pp -= tb1;
        }
    }
}

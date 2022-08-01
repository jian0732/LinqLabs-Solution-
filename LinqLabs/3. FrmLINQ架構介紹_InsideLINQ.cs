using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmLINQ架構介紹_InsideLINQ : Form
    {
        public FrmLINQ架構介紹_InsideLINQ()
        {
            InitializeComponent();
        }

        private void button30_Click(object sender, EventArgs e)
        {
           ArrayList list= new ArrayList();
            list.Add(1);
            list.Add(2);

            var q = from n in list.Cast<int>()
                    select new { N = n };
            dataGridView1.DataSource = q.ToList();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.productsTableAdapter1.Fill(nwDataSet1.Products);
            var q = (from n in this.nwDataSet1.Products
                     orderby n.UnitsInStock descending
                     select n).Take(5);
            dataGridView1.DataSource = q.ToList();

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listBox1.Items.Add("加"+nums.Sum());
            listBox1.Items.Add("最大"+nums.Max());
            listBox1.Items.Add("最小"+nums.Min());
            listBox1.Items.Add("平均"+nums.Average());
            listBox1.Items.Add("總數" + nums.Count());
            listBox1.Items.Add(nwDataSet1.Products.Max(n => n.UnitPrice));

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        //int MyMax()
        //{
        //    for (int i = 0; i < length; i++)
        //    {

        //    }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            this.productPhotoTableAdapter1.Fill(this.awDataSet11.ProductPhoto);
            var q = from n in awDataSet11.ProductPhoto.Distinct()
                    orderby n.ModifiedDate
                    select n.ModifiedDate.Year;
            foreach (int m in q.Distinct())
            {
                comboBox3.Items.Add(m.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            var q = from n in awDataSet11.ProductPhoto select n;
            dataGridView1.DataSource = q.ToList();

            //var t = from n in awDataSet11.ProductPhoto
            //        select n.ThumbNailPhoto;
            //dataGridView1.DataSource = q;
            //pictureBox1.Image =t;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate >= dateTimePicker1.Value && n.ModifiedDate <= dateTimePicker2.Value
                    orderby n.ModifiedDate.Year
                    select n;
            dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow is null)
                return;
            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate.Year == Convert.ToInt32(comboBox3.Text)
                    orderby n.ModifiedDate.Year
                    select n;
            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "第一季")
                方季(0, 4);
            else if (comboBox2.Text == "第二季")
                方季(3, 7);
            else if (comboBox2.Text == "第三季")
                方季(6, 10);
            else
                方季(9, 13);

        }
        void 方季(int k, int p)
        {
            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate.Year == Convert.ToInt32(comboBox3.Text) && n.ModifiedDate.Month > k && n.ModifiedDate.Month < p
                    orderby n.ModifiedDate.Month
                    select n;
            dataGridView1.DataSource = q.ToList();
            label1.Text = "有"+dataGridView1.Rows.Count+"筆";
        }

        //private Image ConvertToImage(byte[] picBinary)
        //{
        //    Image image = null;
        //    using (MemoryStream ms =new MemoryStream(picBinary))
        //    {
        //        image = Image.FromStream(ms);
        //    }
        //    return image;
        //}
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //    _index = e.RowIndex;

            //    int id = (int)dataGridView1.Rows[_index].Cells[0].Value;
            //    List<byte[]> bytelist = this.awDataSet11.ProductPhoto.Where(p => p.ProductPhotoID == id).Select(p => p.LargePhoto).ToList();
            //    byte[] pic = bytelist[0];
            //    pictureBox1.Image = ConvertToImage(pic);
            //}
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cbindex = comboBox3.SelectedIndex;
            int[] index = { 0, 1, 2, 3, };
            foreach (int n in index)
            {
                if (n == cbindex)
                {
                    return;
                }
            }
        }
    }
}
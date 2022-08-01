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
            productPhotoTableAdapter1.Fill(awDataSet11.ProductPhoto);
        }
        int _index=-1;
        private void button11_Click(object sender, EventArgs e)
        {
          
            var q = from n in awDataSet11.ProductPhoto
                    select n;
            dataGridView1.DataSource = q.ToList();
            //==============================
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate > dateTimePicker1.Value && n.ModifiedDate < dateTimePicker2.Value
                    select n;
            dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(comboBox3.Text);
            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate.Year == i
                    select n;
            dataGridView1.DataSource = q.ToList();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                方法(1, 3);
            }
            if (comboBox2.SelectedIndex == 1)
            {
                方法(4, 7);
            }
            if (comboBox2.SelectedIndex == 2)
            {
                方法(8, 10);
            }
            if (comboBox2.SelectedIndex == 3)
            {
                方法(10, 12);
            }

        }
        void 方法(int aa,int bb)
        {
            var q = from n in awDataSet11.ProductPhoto
                    where n.ModifiedDate.Year == Convert.ToInt32(comboBox3.Text) 
                    &&n.ModifiedDate.Month >= aa && n.ModifiedDate.Month <= bb
                    select n;
                    
            dataGridView1.DataSource = q.ToList();
            label1.Text = "總共有" +q.ToList().Count()+"筆資料";
        }

        private Image ConvertToImage(byte[] picBinary)
        {
            Image image = null;
            using (MemoryStream ms =new MemoryStream(picBinary))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {




        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _index = e.RowIndex;
            
            int id = (int)dataGridView1.Rows[_index].Cells[0].Value;
            List<byte[]> bytelist = this.awDataSet11.ProductPhoto.Where(p => p.ProductPhotoID == id).Select(p => p.LargePhoto).ToList();
            byte[] pic = bytelist[0];
            pictureBox1.Image = ConvertToImage(pic);
        }
    }
}

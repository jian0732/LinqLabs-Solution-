using LinqLabs.作業;
using MyHomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             Frm作業_1 a= new Frm作業_1();
            a.MdiParent = this;
            a.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Frm作業_2 c = new Frm作業_2();
            c.MdiParent = this;
            c.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Frm作業_3 c = new Frm作業_3();
            c.MdiParent = this;
            c.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Frm作業_4 c = new Frm作業_4();
            c.MdiParent = this;
            c.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild!=null)
            this.ActiveMdiChild.Close();
        }
    }
}

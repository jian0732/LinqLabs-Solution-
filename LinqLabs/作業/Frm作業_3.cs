using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyHomeWork.Frm作業_1;

namespace LinqLabs.作業
{
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
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
        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            var q = from PK in students_scores
                    group PK by 分級方法(PK.Math) into AV
                    select new { 分級 = AV.Key, 幾個人 = AV.Count() };


            dataGridView1.DataSource = q.ToList();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        
        private void button36_Click(object sender, EventArgs e)
        {
            var q = from n in students_scores
                    select n;
            dataGridView1.DataSource = q.ToList();

            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Chi";
            chart1.Series[0].Name = "國文";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].XValueMember = "Name";
            chart1.Series[1].YValueMembers = "Eng";
            chart1.Series[1].Name = "英文";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[2].XValueMember = "Name";
            chart1.Series[2].YValueMembers = "Math";
            chart1.Series[2].Name = "數學";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.DataSource = q.ToList();
        }
        string 分級方法(int n)
        {
            if (n < 60)
                return "放牛班";
            else if (n >= 60 && n <= 69)
                return "待加強";
            else if (n >= 70 && n <= 89)
                return "佳";
            else
                return "優良";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var q = from n in students_scores
                    where n.Name == "宏哥"
                    select n;
            dataGridView1.DataSource = q.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from KK in students_scores
                    group KK by KK.Class into h
                    select new { Class = h.Key, 國文平均成績 = h.Average(KK => KK.Chi), 英文平均成績 = h.Average(KK => KK.Eng), 數學平均成績 = h.Average(KK => KK.Math), 總平均成績 = h.Average(KK => (KK.Eng + KK.Chi + KK.Math) / 3) };
            dataGridView1.DataSource = q.ToList();

            chart1.Series[0].XValueMember = "Class";
            chart1.Series[0].YValueMembers = "國文平均成績";
            chart1.Series[0].Name = "國文平均成績";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].XValueMember = "Class";
            chart1.Series[1].YValueMembers = "英文平均成績";
            chart1.Series[1].Name = "英文平均成績";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[2].XValueMember = "Class";
            chart1.Series[2].YValueMembers = "數學平均成績";
            chart1.Series[2].Name = "數學平均成績";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[3].XValueMember = "Class";
            chart1.Series[3].YValueMembers = "總平均成績";
            chart1.Series[3].Name = "總平均成績";
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.DataSource = q.ToList();
        }
    }
}

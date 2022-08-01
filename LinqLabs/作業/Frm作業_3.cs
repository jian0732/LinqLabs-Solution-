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
                                            new Student{ Name = "宏哥", Class = "CS_101", Chi = 20, Eng = 0, Math = 50, Gender = "Male" },
                                            new Student{ Name = "寧哥", Class = "CS_102", Chi = 10, Eng = 0, Math = 100, Gender = "Male" },
                                            new Student{ Name = "JAVA哥", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "然哥", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "佑哥", Class = "CS_101", Chi = 70, Eng = 5, Math = 50, Gender = "Female" },
                                            new Student{ Name = "兆哥", Class = "CS_102", Chi = 85, Eng = 50, Math = 80, Gender = "Female" },

                                          };
        }
        List<Student> students_scores;
        private void button33_Click(object sender, EventArgs e)
        {
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        
        private void button36_Click(object sender, EventArgs e)
        {
            //var q = from n in students_scores

            //        select n;

            var c = from n in students_scores
                    select n;
            dataGridView1.DataSource = c.ToList();

            //=================================
            chart1.DataSource = c.ToList();
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = "Chi";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[1].XValueMember = "Name";
            chart1.Series[1].YValueMembers = "Eng";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart1.Series[2].XValueMember = "Name";
            chart1.Series[2].YValueMembers = "Math";
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

        }
        string Mypoint(int a)
        {
            if (a < 60)
                return "不及格";
            else if (a <81)
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
    }
}

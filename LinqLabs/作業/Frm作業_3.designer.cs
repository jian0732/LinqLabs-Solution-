﻿
namespace LinqLabs.作業
{
    partial class Frm作業_3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productsTableAdapter1 = new LinqLabs.NWDataSetTableAdapters.ProductsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(366, 52);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "國文";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "英文";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "數學";
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(483, 243);
            this.chart1.TabIndex = 147;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button36.Location = new System.Drawing.Point(17, 22);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(250, 50);
            this.button36.TabIndex = 146;
            this.button36.Text = "搜尋 班級學生成績";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button37.Location = new System.Drawing.Point(17, 87);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(250, 50);
            this.button37.TabIndex = 145;
            this.button37.Text = "每個學生個人成績";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(17, 208);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(250, 50);
            this.button33.TabIndex = 143;
            this.button33.Text = "自己分群";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(366, 301);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(483, 209);
            this.dataGridView1.TabIndex = 148;
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 47);
            this.button1.TabIndex = 149;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm作業_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button33);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm作業_3";
            this.Text = "Frm作業_3";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.DataGridView dataGridView1;
        private NWDataSetTableAdapters.ProductsTableAdapter productsTableAdapter1;
        private System.Windows.Forms.Button button1;
    }
}